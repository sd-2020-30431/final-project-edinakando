using Recipes.BusinessLogic.Extensions;
using Recipes.BusinessLogic.Models;
using Recipes.DataAccess.Entities;
using Recipes.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.BusinessLogic.Logic
{
    public class RecipesLogic
    {
        private readonly RecipesRepository _recipesRepository;

        public RecipesLogic(RecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository;
        }

        public async Task<Int32> AddRecipe(RecipeDto recipe)
        {
            var recipeIdResult = await _recipesRepository.AddRecipe(new Recipe
            {
                Name = recipe.Name,
                Instructions = recipe.Instructions,
                UserId = recipe.UserId,
            });

            await _recipesRepository.AddIngredients(recipe.Ingredients.Select(i => new Ingredient
            {
                Name = i.Name,
                Quantity = i.Quantity,
                RecipeId = recipeIdResult
            }).ToList());

            return recipeIdResult;
        }

        public async Task AddImageToRecipe(Int32 recipeId, String path)
        {
            await _recipesRepository.AddImage(recipeId, path);
        }

        public async Task<List<RecipeDto>> GetRecipesHeadlines()
        {
            var recipesResult = await _recipesRepository.GetRecipesHeadlines();
            return recipesResult.Select(r => r.ToRecipeDto()).ToList();
        }
    }
}