using Recipes.BusinessLogic.Models;
using Recipes.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.BusinessLogic.Extensions
{
    public static class UserExtensions
    {
        public static UserDto ToUserDto(this User model)
        {
            if (model == null)
                return null;

            return new UserDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Type = (UserTypeDto)Enum.Parse(typeof(UserTypeDto), model.Role.Name)
            };
        }
    }
}
