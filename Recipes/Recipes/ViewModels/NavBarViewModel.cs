using System;

namespace Recipes.ViewModels
{
    public class NavBarViewModel
    {
        public Boolean IsLoggedIn { get; set; } = false;
        public Boolean IsChef { get; set; } = false;
        public String UserName { get; set; }
    }
}
