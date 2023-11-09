using Microsoft.AspNetCore.Mvc.Filters;

namespace Ornek1.Attributes
{
    public class LogAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string ipNumarasi = context.HttpContext.Request.Host.Value.ToString();
            string metotAdi = context.ActionDescriptor.DisplayName;

        }

    }
}
