using Microsoft.AspNetCore.Mvc;

namespace Ornek1.ViewComponents
{
    public class KullaniciBilgiViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var userNameCerez = Request.Cookies["Oturum"];
            if(userNameCerez == null)
            {
                return View("_kullaniciBilgi",new DataModel.Market.Kullanici());
            }
            else { 
                DataModel.Market.MarketContext model = new DataModel.Market.MarketContext();
                var kullanici = model.Kullanici.FirstOrDefault(k => k.KullaniciAdi == userNameCerez);
                return View("_kullaniciBilgi",kullanici); 
            
            }
            
        }
    }
}
