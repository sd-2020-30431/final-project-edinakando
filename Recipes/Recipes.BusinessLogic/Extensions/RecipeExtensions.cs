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
                Name = model.Name,
                Instructions = model.Instructions,
                User = model.User.ToUserDto(),
                ImagePaths = model.Images.Select(i => i.Path).ToList()
            };
        }
    }
}