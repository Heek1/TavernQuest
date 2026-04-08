using Microsoft.AspNetCore.Mvc;

namespace TavernQuest.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => RedirectToAction("Index", "Tavern");
}
