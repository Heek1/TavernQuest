namespace TavernQuest.Models;

public class TavernViewModel
{
    public string KeeperName { get; set; } = "";
    public int TotalVisitors { get; set; }
    public string VisitId { get; set; } = "";
    public List<string> Orders { get; set; } = new();
    public decimal TotalBill { get; set; }
    public int DiceD20 { get; set; }
    public int DiceD6 { get; set; }
    public string Message { get; set; } = "";
}

public class OrderInputModel
{
    public string Item { get; set; } = "";
    public decimal Price { get; set; }
}
