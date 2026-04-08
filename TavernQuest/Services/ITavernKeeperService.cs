namespace TavernQuest.Services;

public interface ITavernKeeperService
{
    string Name { get; }
    int TotalVisitors { get; }
    void RegisterVisitor();
}

public class TavernKeeperService : ITavernKeeperService
{
    private int _totalVisitors = 0;

    public string Name { get; } = "Балдур Бронзова Борода";
    public int TotalVisitors => _totalVisitors;

    public TavernKeeperService()
    {
        Console.WriteLine($"[Singleton] {Name}");
    }

    public void RegisterVisitor()
    {
        Interlocked.Increment(ref _totalVisitors);
    }
}
