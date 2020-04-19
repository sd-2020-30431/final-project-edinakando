using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Recipes.BusinessLogic.Models;
using Recipes.Extensions;
using System;

namespace Recipes.Filters
{
    public class UserIsLoggedInFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            UserDto user = context.HttpContext.Session.Get<UserDto>("User");

            if (user != null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary{ { "Controller", "Home" },
                                                {"Action", "Index" } });
            }
        }
    }
}