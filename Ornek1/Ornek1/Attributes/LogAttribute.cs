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
        
            var parametreListe = context.ActionDescriptor.Parameters;
            if (parametreListe!=null && parametreListe.Count>0)
            { 
                ///todo:parametreleri jsonad dönüştürüp log tablosuna eklenecek.
                ///
                string jsonParametre = JsonSerializer.Serialize(context.ActionArguments);
                yeniLog.Parametre = jsonParametre;
             
            }
            model.Log.Add(yeniLog);
            model.SaveChanges();
        }

    }
}
