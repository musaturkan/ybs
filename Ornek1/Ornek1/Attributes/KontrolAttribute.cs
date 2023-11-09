using Microsoft.AspNetCore.Mvc.Filters;

namespace Ornek1.Attributes
{
    public class KontrolAttribute:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string metotAdi = context.ActionDescriptor.DisplayName;
        }
    }
}
