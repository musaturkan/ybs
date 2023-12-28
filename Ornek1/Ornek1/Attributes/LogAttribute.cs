using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace Ornek1.Attributes
{
    public class LogAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            DataModel.Market.MarketContext model=new DataModel.Market.MarketContext();
            DataModel.Market.Log yeniLog = new DataModel.Market.Log();

            yeniLog.Ip= context.HttpContext.Request.Host.Value.ToString();
            yeniLog.MetotAdi = context.ActionDescriptor.DisplayName;
            yeniLog.TalepYapilanUrl=context.ActionDescriptor.DisplayName;
            yeniLog.Tarayici=context.HttpContext.Request.Headers["User-Agent"].ToString();
            yeniLog.Tarih = DateTime.Now;

            var parametreListe = context.ActionDescriptor.Parameters;
            if (parametreListe!=null && parametreListe.Count>0)
            {                 
                string jsonParametre = JsonSerializer.Serialize(context.ActionArguments);
                yeniLog.Parametre = jsonParametre;
             
            }

            if (context.HttpContext.User!=null && 
                context.HttpContext.User.Identity!=null &&
                context.HttpContext.User.Identity.IsAuthenticated==true)
            {
                string userId = context.HttpContext.User.Claims.FirstOrDefault(p => p.Type == "Id").Value;
                yeniLog.KullaniciId=Convert.ToInt32(userId);
            }
            model.Log.Add(yeniLog);
            model.SaveChanges();
        }

    }
}
