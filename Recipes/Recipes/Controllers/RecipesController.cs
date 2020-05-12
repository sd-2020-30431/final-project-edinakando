using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.BusinessLogic.Logic;
using Recipes.BusinessLogic.Models;
using Recipes.Extensions;
using Recipes.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Controllers
{
    public class RecipesController : Controller
    {
        private readonly RecipesLogic _recipesLogic;
        private readonly IHostingEnvironment _environment;

        public RecipesController(RecipesLogic recipesLogic, IHostingEnvironment environment)
        {
            _recipesLogic = recipesLogic;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe(RecipeViewModel recipe)
        {
            UserDto currentUser = HttpContext.Session.Get<UserDto>("User");
            var recipeIdResult = await _recipesLogic.AddRecipe(new RecipeDto
            {
                Name = recipe.Name,
                Instructions = recipe.Instructions,
                UserId = currentUser.ID,
                Ingredients = recipe.Ingredients.Select(i => new IngredientDto
                {
                    Name = i.Name,
                    Quantity = i.Quantity
                }).ToList()
            });

            return Json(recipeIdResult);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, Int32 recipeId)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (file.Length > 0)
            {
                String path = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                await _recipesLogic.AddImageToRecipe(recipeId, Path.Combine("uploads", file.FileName));
            }
            return RedirectToAction("AddRecipe");
        }

        [HttpGet]
        public async Task<IActionResult> Recipe(Int32 recipeId)
        {
            var recipe = await _recipesLogic.GetRecipeById(recipeId);

            var recipeViewModel = new RecipeViewModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Instructions = recipe.Instructions,
                Ingredients = recipe.Ingredients.Select(r => new IngredientViewModel
                {
                    Name = r.Name,
                    Quantity = r.Quantity
                }).ToList(),
                User = recipe.User.ToUserViewModel(),
                Images = recipe.ImagePaths,
                Comments = (await _recipesLogic.GetComments(recipe.Id)).Select(c => new CommentViewModel
                {
                    UserName = c.UserName,
                    Message = c.Message,
                    Date = c.Date
                }).ToList()
            };
            return View(recipeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentViewModel comment)
        {
            await _recipesLogic.AddComment(comment.ToCommentDto());
            return Ok();
        }
    }
}