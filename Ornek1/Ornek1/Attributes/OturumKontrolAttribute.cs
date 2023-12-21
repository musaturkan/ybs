using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ornek1.Attributes;

public class OturumKontrolAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.HttpContext.User.Identity==null 
            || context.HttpContext.User.Identity.IsAuthenticated == false
            || context.HttpContext.User.Claims==null
            || context.HttpContext.User.Claims.Count()==0)
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Oturum", action = "Index" }));
        }
    }
}

