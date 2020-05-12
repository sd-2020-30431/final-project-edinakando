using System;
using System.Collections.Generic;

namespace Recipes.ViewModels
{
    public class RecipeViewModel
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
        public String Instructions { get; set; }
        public Int32 UserId { get; set; }
        public UserViewModel User { get; set; }
        public List<String> Images { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}