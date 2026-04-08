namespace TavernQuest.Services;

public interface IDiceService
{
    int LastRoll { get; }
    int Roll(int sides = 20);
}

public class DiceService : IDiceService
{
    private int _lastRoll;

    public int LastRoll => _lastRoll;

    public DiceService()
    {
        _lastRoll = Random.Shared.Next(1, 21);
        Console.WriteLine($"[Transient] Roll: {_lastRoll}");
    }

    public int Roll(int sides = 20)
    {
        _lastRoll = Random.Shared.Next(1, sides + 1);
        return _lastRoll;
    }
}
