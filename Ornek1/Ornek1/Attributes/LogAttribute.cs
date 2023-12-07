using Microsoft.AspNetCore.Mvc.Filters;

namespace Ornek1.Attributes
{
    public class LogAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Models.MarketContext model=new Models.MarketContext();
            Models.Log yeniLog = new Models.Log();

            yeniLog.Ip= context.HttpContext.Request.Host.Value.ToString();
            yeniLog.MetotAdi = context.ActionDescriptor.DisplayName;
            yeniLog.TalepYapilanUrl=context.ActionDescriptor.DisplayName;
            yeniLog.Tarayici=context.HttpContext.Request.Headers["User-Agent"].ToString();
            //yeniLog.Parametre=context.ActionDescriptor.Parameters.ToString();
            var parametreListe = context.ActionDescriptor.Parameters;
            if (parametreListe!=null && parametreListe.Count>0)
            {
             
              ///todo:parametreleri jsonad dönüştürüp log tablosuna eklenecek.
            }
            model.Log.Add(yeniLog);
            model.SaveChanges();
        }

    }
}
