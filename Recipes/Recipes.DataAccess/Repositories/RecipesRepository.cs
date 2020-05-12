using Microsoft.EntityFrameworkCore;
using Recipes.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipes.DataAccess.Repositories
{
    public class RecipesRepository
    {
        private readonly RecipesDbContext _context;

        public RecipesRepository(RecipesDbContext context)
        {
            _context = context;
        }

        public async Task<Int32> AddRecipe(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
            return recipe.Id;
        }

        public async Task AddIngredients(List<Ingredient> ingredients)
        {
            foreach (var ingredient in ingredients)
                await _context.AddAsync(ingredient);

            await _context.SaveChangesAsync();
        }

        public async Task AddImage(Int32 recipeId, String imagePath)
        {
            await _context.Images.AddAsync(new Image
            {
                RecipeId = recipeId,
                Path = imagePath
            });
            await _context.SaveChangesAsync();
        }

        public async Task<List<Recipe>> GetRecipesHeadlines()
        {
            return await _context.Recipes.Include(r => r.Images)
                                .Include(r => r.Ingredients)
                                .Include(r => r.User)
                                .ThenInclude(r => r.Role)
                                .ToListAsync();
        }

        public async Task<Recipe> GetRecipeById(int id)
        {
            return await _context.Recipes.Include(r => r.Images)
                            .Include(r => r.Ingredients)
                            .Include(r => r.User)
                            .ThenInclude(r => r.Role)
                            .FirstAsync();
        }

        public async Task AddComment(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }
    }
}
