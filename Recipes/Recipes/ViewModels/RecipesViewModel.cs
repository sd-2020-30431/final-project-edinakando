using System.Collections.Generic;

namespace Recipes.ViewModels
{
    public class RecipesViewModel
    {
        public IList<RecipeViewModel> Recipes { get; set; }

        public RecipesViewModel()
        {
            Recipes = new List<RecipeViewModel>();
        }
    }
}