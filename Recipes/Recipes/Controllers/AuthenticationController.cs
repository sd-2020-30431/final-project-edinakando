using Microsoft.AspNetCore.Mvc;
using Recipes.BusinessLogic.Logic;
using Recipes.BusinessLogic.Models;
using Recipes.Extensions;
using Recipes.Filters;
using Recipes.ViewModels;
using System;
using System.Threading.Tasks;

namespace Recipes.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserLogic _userLogic;

        public AuthenticationController(UserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpGet]
        [UserIsLoggedInFilter]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [UserIsLoggedInFilter]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            UserDto user = await _userLogic.GetUserByEmail(loginViewModel.Email);

            if (user != null && await _userLogic.VerifyPassword(user, loginViewModel.Password))
            {
                HttpContext.Session.Set<UserDto>("User", user);
                return RedirectToAction("Index", "Home");
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [UserIsLoggedInFilter]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            UserDto user = await _userLogic.GetUserByEmail(registerViewModel.Email);

            if (user != null)
            {
                return BadRequest();
            }

            user = await _userLogic.InsertNewUser(new UserDto{
                FirstName = registerViewModel.FirstName, 
                LastName = registerViewModel.LastName, 
                Email = registerViewModel.Email, 
                Password = registerViewModel.Password,
                Type = (UserTypeDto)Enum.Parse(typeof(UserTypeDto), registerViewModel.Type.ToString())
            });

            HttpContext.Session.Set<UserDto>("User", user);
            return Json(user);
        }

        public IActionResult SuccessRegister()
        {
            return View();
        }

        [HttpGet]
        public Boolean IsUserLoggedIn()
        {
            return HttpContext.Session.Get<UserDto>("User") != null;
        }
    }
}