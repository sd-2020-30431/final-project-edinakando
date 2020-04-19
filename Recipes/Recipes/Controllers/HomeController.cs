using Microsoft.AspNetCore.Mvc;

namespace Recipes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
