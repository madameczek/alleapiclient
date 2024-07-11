using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using costcollector.App.Entities;
using costcollector.App.Interfaces;
using costcollector.App.Services;
using costcollector.Common;
using costcollector.Common.Configuration;
using costcollector.Infrastructure.HttpClients;
using costcollector.Infrastructure.Persistence.DbContexts;
using costcollector.Infrastructure.Persistence.Repositories;
using costcollector.Infrastructure.TokenReaders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var appBuilder = Host.CreateApplicationBuilder();

appBuilder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true, false);
appBuilder.Services.Configure<CostTypes>(appBuilder.Configuration.GetSection(CostTypes.CostTypesSection));

appBuilder.Services.AddTransient<ICostTypeProvider, AppSettingsCostTypeProvider>();
appBuilder.Services.AddTransient<IPaymentParser, PaymentParser>();
appBuilder.Services.AddTransient<IAllegroService, AllegroService>();
appBuilder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
appBuilder.Services.AddTransient<IAllegroService, AllegroService>();
appBuilder.Services.AddTransient<IPaymentService, PaymentService>();

appBuilder.Services.AddDbContext<OrdersDbContext>(options =>
{
    options.UseSqlServer(appBuilder.Configuration.GetConnectionString("Orders"));
    options.UseSqlServer(optionsBuilder => optionsBuilder.EnableRetryOnFailure());
});

appBuilder.Services.AddHttpClient<IAllegroClient, AllegroClient>(c =>
{
    var allegroSettings = appBuilder.Configuration.GetSection("Allegro").Get<AllegroClientSettings>();
    if (allegroSettings?.BaseAddress is null)
        throw new ApplicationException("Bad app configuration.");
    
    var token = TokenReader.GetToken();
    c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  token?? allegroSettings.AccessToken);
    c.DefaultRequestHeaders.Add("Accept", "application/vnd.allegro.public.v1+json");
    c.BaseAddress = new Uri(allegroSettings.BaseAddress);
});

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    Converters = { new AllegroValueConverter(), new AllegroTaxConverter(), new AllegroOfferConverter() }
};
appBuilder.Services.AddSingleton(options);

var host = appBuilder.Build();

// here application starts
var allegroService = host.Services.GetRequiredService<IAllegroService>();
var paymentService = host.Services.GetRequiredService<IPaymentService>();

var orders = await paymentService.GetOrders();
foreach (var order in (orders as List<Order>)!)
{
    var payments = await allegroService.FetchPayments(order.OrderId);
    foreach (var payment in payments)
    {
        await paymentService.SavePayment(payment);
    }
}

var fixedCosts = await paymentService.GetCosts(1);
Console.WriteLine("Koszty stałe:");
foreach (var cost in fixedCosts)
{
    Console.WriteLine(JsonSerializer.Serialize(cost));
}