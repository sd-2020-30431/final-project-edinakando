using Recipes.BusinessLogic.Models;
using Recipes.DataAccess.Entities;
using System.Linq;

namespace Recipes.BusinessLogic.Extensions
{
    public static class RecipeExtensions
    {
        public static RecipeDto ToRecipeDto(this Recipe model)
        {
            if (model == null)
                return null;

            return new RecipeDto
            {
                Id = model.Id,
                Name = model.Name,
                Instructions = model.Instructions,
                User = model.User.ToUserDto(),
                ImagePaths = model.Images.Select(i => i.Path).ToList(),
                Ingredients = model.Ingredients.Select(i => i.ToIngredientDto()).ToList(),
                Comments = model.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static IngredientDto ToIngredientDto(this Ingredient model)
        {
            if (model == null)
                return null;

            return new IngredientDto
            {
                Name = model.Name,
                Quantity = model.Quantity
            };
        }

        public static CommentDto ToCommentDto(this Comment model)
        {
            if (model == null)
                return null;

            return new CommentDto
            {
                UserName = model.UserName,
                Message = model.Message,
                Date = model.Date
            };
        }
    }
}