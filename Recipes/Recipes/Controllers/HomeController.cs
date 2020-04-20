using Microsoft.AspNetCore.Mvc;
using Recipes.BusinessLogic.Logic;
using Recipes.Extensions;
using Recipes.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Controllers
{
    public class HomeController : Controller
    {
        private readonly RecipesLogic _recipesLogic;

        public HomeController(RecipesLogic recipesLogic)
        {
            _recipesLogic = recipesLogic;
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await _recipesLogic.GetRecipesHeadlines();
            return View(new RecipesViewModel
            {
                Recipes = recipes.Select(r => new RecipeViewModel
                {
                    Name = r.Name,
                    User = r.User.ToUserViewModel()
                }).ToList()
            });
        }
    }
}