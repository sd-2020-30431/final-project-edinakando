using Recipes.BusinessLogic.Models;
using Recipes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Extensions
{
    public static class ModelBinderExtension
    {
        public static UserViewModel ToUserViewModel(this UserDto model)
        {
            if (model == null)
                return null;

            return new UserViewModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }

        public static CommentDto ToCommentDto(this CommentViewModel model)
        {
            if (model == null)
                return null;

            return new CommentDto
            {
                RecipeId = model.RecipeId,
                UserName = model.UserName,
                Message = model.Message
            };
        }
    }
}
