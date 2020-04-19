using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Recipes.BusinessLogic.Models;
using Recipes.Extensions;
using System;

namespace Recipes.Filters
{
    public class RequireAuthentication : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            UserDto user = context.HttpContext.Session.Get<UserDto>("User");
            var controller = context.ActionDescriptor as ControllerActionDescriptor;
            //Attribute bypassAttributeOnMethod = controller.MethodInfo.GetCustomAttribute<AllowAnonymous>();
            //Attribute bypassAttributeOnController = controller.ControllerTypeInfo.GetCustomAttribute<AllowAnonymous>();

            if (user == null) //&& bypassAttributeOnMethod == null && bypassAttributeOnController == null
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary{ { "Controller", "Authentication" },
                                                {"Action", "Login" } });
            }
        }
    }
}
