using Recipes.BusinessLogic.Extensions;
using Recipes.BusinessLogic.Models;
using Recipes.BusinessLogic.Shared;
using Recipes.DataAccess;
using Recipes.DataAccess.Entities;
using Recipes.DataAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace Recipes.BusinessLogic.Logic
{
    public class UserLogic
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;

        public UserLogic(UserRepository userRepository, RoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserDto> GetUserByEmail(String email)
        {
            var result = await _userRepository.GetUserByEmail(email);
            return result.ToUserDto();
        }

        public async Task<Boolean> VerifyPassword(UserDto user, String password)
        {
            return await _userRepository.CheckUserPassword(user.Email, HashingSHA.GenerateSHA256String(password));
        }

        public async Task<UserDto> InsertNewUser(UserDto user)
        {
            var result = await _userRepository.AddUser(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = await _roleRepository.GetRole(user.Type.ToString()),
                Password = HashingSHA.GenerateSHA256String(user.Password)
            });
            return result.ToUserDto();
        }
    }
}