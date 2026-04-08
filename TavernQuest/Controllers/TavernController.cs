using Microsoft.AspNetCore.Mvc;
using TavernQuest.Models;
using TavernQuest.Services;

namespace TavernQuest.Controllers;

public class TavernController : Controller
{
    private readonly ITavernKeeperService _keeper;
    private readonly IVisitService _visit;
    private readonly IDiceService _dice1;
    private readonly IDiceService _dice2;

    public TavernController(
        ITavernKeeperService keeper,
        IVisitService visit,
        IDiceService dice1,
        IDiceService dice2)
    {
        _keeper = keeper;
        _visit = visit;
        _dice1 = dice1;
        _dice2 = dice2;
    }

    public IActionResult Index()
    {
        var vm = new TavernViewModel
        {
            KeeperName = _keeper.Name,
            TotalVisitors = _keeper.TotalVisitors,
            VisitId = _visit.VisitId,
            Orders = _visit.Orders,
            TotalBill = _visit.TotalBill,
            DiceD20 = _dice1.LastRoll,
            DiceD6 = _dice2.LastRoll
        };
        return View(vm);
    }

    [HttpPost]
    public IActionResult Enter()
    {
        _keeper.RegisterVisitor();
        TempData["Message"] = $"{_keeper.Name} welcomes visitor #{_keeper.TotalVisitors}.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult AddOrder(OrderInputModel input)
    {
        if (string.IsNullOrWhiteSpace(input.Item) || input.Price <= 0)
        {
            TempData["Message"] = "Please provide a valid item and price.";
            return RedirectToAction(nameof(Index));
        }

        _visit.AddOrder(input.Item, input.Price);
        TempData["Message"] = $"{input.Item} added. Bill: {_visit.TotalBill:C}";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult RollDice(int sides = 20)
    {
        var result = _dice1.Roll(sides);
        TempData["Message"] = $"Rolled d{sides}: {result}";
        return RedirectToAction(nameof(Index));
    }
}
