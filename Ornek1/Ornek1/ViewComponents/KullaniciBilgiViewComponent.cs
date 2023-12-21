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
            else 
            {
                var user = HttpContext.User;
                var kullaniciAdi = user.Claims.FirstOrDefault(p => p.Type == "KullaniciAdi").Value;
               
                DataModel.Market.Kullanici oturumKullanici = new DataModel.Market.Kullanici();
                oturumKullanici.Ad = user.Claims.FirstOrDefault(p => p.Type == "Ad").Value;
                oturumKullanici.Soyad = user.Claims.FirstOrDefault(p => p.Type == "Soyad").Value;
                oturumKullanici.KayitTarihi = Convert.ToDateTime( user.Claims.FirstOrDefault(p => p.Type == "KayitTarihi").Value);
                oturumKullanici.Id = Convert.ToInt32( user.Claims.FirstOrDefault(p => p.Type == "Id").Value);
                //DataModel.Market.MarketContext model = new DataModel.Market.MarketContext();
                //var kullanici = model.Kullanici.FirstOrDefault(k => k.KullaniciAdi == userNameCerez);
                return View("_kullaniciBilgi",oturumKullanici); 
            
            }
            
        }
    }
}
