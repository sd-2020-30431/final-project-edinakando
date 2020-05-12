using System;

namespace Recipes.BusinessLogic.Models
{
    public class CommentDto
    {
        public int RecipeId { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
