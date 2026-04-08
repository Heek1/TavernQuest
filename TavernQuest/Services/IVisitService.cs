namespace TavernQuest.Services;

public interface IVisitService
{
    string VisitId { get; }
    List<string> Orders { get; }
    decimal TotalBill { get; }
    void AddOrder(string item, decimal price);
}

public class VisitService : IVisitService
{
    private readonly List<string> _orders = new();
    private decimal _totalBill = 0;

    public string VisitId { get; }
    public List<string> Orders => _orders;
    public decimal TotalBill => _totalBill;

    public VisitService()
    {
        VisitId = "VIS-" + Guid.NewGuid().ToString()[..8].ToUpper();
        Console.WriteLine($"[Scoped] {VisitId}");
    }

    public void AddOrder(string item, decimal price)
    {
        _orders.Add($"{item} ({price:C})");
        _totalBill += price;
    }
}
