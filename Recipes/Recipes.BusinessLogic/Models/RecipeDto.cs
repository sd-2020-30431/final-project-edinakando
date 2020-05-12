using System;
using System.Collections.Generic;

namespace Recipes.BusinessLogic.Models
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
        public String Instructions { get; set; }
        public Int32 UserId { get; set; }
        public UserDto User { get; set; }
        public List<String> ImagePaths { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
