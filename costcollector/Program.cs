using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using costcollector.App.Interfaces;
using costcollector.App.Services;
using costcollector.Common;
using costcollector.Common.Configuration;
using costcollector.Infrastructure.HttpClients;
using costcollector.Infrastructure.Models;
using costcollector.Infrastructure.Persistence.DbContexts;
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

await using var repo = host.Services.GetRequiredService<OrdersDbContext>();
var orders = repo.Orders.ToArray();
foreach (var order in orders)
{
    Console.WriteLine(order.OrderId);
}

var allegro = host.Services.GetRequiredService<IAllegroClient>();
var payments = await allegro.GetPayments();
var serializerOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
};
foreach (var payment in payments)
{
    Console.WriteLine(payment.Type.Id is "SUC" or "USF"
        ? JsonSerializer.Serialize((AllegroTransactionCost)payment, serializerOptions)
        : JsonSerializer.Serialize(payment, serializerOptions));
}

Console.ReadKey();