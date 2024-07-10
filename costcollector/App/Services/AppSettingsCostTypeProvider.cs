using costcollector.App.Interfaces;
using costcollector.Common.Configuration;
using Microsoft.Extensions.Options;

namespace costcollector.App.Services;

// TODO implement fetching cost types from database for easy change at runtime
public class AppSettingsCostTypeProvider : ICostTypeProvider
{
    private readonly CostTypes _costTypes;

    public AppSettingsCostTypeProvider(IOptions<CostTypes> costTypes) =>
        _costTypes = costTypes.Value;

    public IEnumerable<string> GetTransactionCostTypes() =>
        _costTypes.TransactionCosts;

    public IEnumerable<string> GetFixedCostTypes() =>
        _costTypes.FixedCosts;
}