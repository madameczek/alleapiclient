namespace costcollector.App.Interfaces;

public interface ICostTypeProvider
{
    public IEnumerable<string> GetTransactionCostTypes();
    public IEnumerable<string> GetFixedCostTypes();
}