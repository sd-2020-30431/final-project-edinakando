using System;

namespace Recipes.ViewModels
{
    public class CommentViewModel
    {
        public int RecipeId { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
