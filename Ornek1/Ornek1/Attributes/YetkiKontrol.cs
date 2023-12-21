using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ornek1.Attributes
{
    public class YetkiKontrol : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var actionDetay = context.ActionDescriptor as ControllerActionDescriptor;

                DataModel.Market.MarketContext model = new DataModel.Market.MarketContext();
                var kullaniciAdi = context.HttpContext.User.Claims.FirstOrDefault(p => p.Type == "KullaniciAdi").Value;
                if (kullaniciAdi != null)
                {
                    var kullaniciRolListe=model.KullaniciRol.Where(p=>p.Kullanici.KullaniciAdi==kullaniciAdi).ToList();
                    var metotRolListe = model.Yetki.Where(p => p.Metot.Ad == actionDetay.ActionName).ToList();

                    var rolVarMi= metotRolListe.Any(p=>kullaniciRolListe.Any(k=>k.RolId==p.RolId));
                    if (rolVarMi!=true)
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Oturum", action = "Index" }));
                    }
                }

            }
        }
    }
}
