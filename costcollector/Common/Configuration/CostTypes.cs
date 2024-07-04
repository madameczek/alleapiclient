namespace costcollector.Common.Configuration;

public class CostTypes
{
    public const string CostTypesSection = "CostTypes";

    public IEnumerable<string> FixedCosts { get; set; } = Array.Empty<string>();
    public IEnumerable<string> TransactionCosts { get; set; } = Array.Empty<string>();
}