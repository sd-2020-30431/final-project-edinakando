using Microsoft.AspNetCore.Mvc;
using Recipes.BusinessLogic.Models;
using Recipes.Extensions;
using Recipes.ViewModels;

namespace Recipes.Components
{
    public class NavBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var navBarViewModel = new NavBarViewModel();
            UserDto user = HttpContext.Session.Get<UserDto>("User");
            if (user != null)
            {
                navBarViewModel.IsLoggedIn = true;
                navBarViewModel.UserName = user.FirstName;
                navBarViewModel.IsChef = user.IsChef();
            }
           
            return View("NavBarViewComponent", navBarViewModel);
        }
    }
}

