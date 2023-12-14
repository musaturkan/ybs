using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ornek1.Controllers
{
    public class OturumController : Controller
    {
        public IActionResult Index()
        {
            Response.Cookies.Delete("Oturum");
            return View();
        }


        [HttpPost]
        public IActionResult OturumAc(Models.Oturum_VM kullanici)
        {
            DataModel.Market.MarketContext model = new DataModel.Market.MarketContext();
            var oturumKullanici=model.Kullanici.FirstOrDefault(k=>k.KullaniciAdi==kullanici.KullaniciAdi && k.Parola==kullanici.Parola);
            if (oturumKullanici != null)
            {
                CookieOptions cerezAyar = new CookieOptions();
                cerezAyar.Expires = DateTime.Now.AddMinutes(30);                
                ///Todo:Oturum çrezi şifrelenecek
                Response.Cookies.Append("Oturum",oturumKullanici.KullaniciAdi,cerezAyar);
                return RedirectToAction("Index", "Urun");
            }
            else
            {
                ViewBag.Mesaj = "Kullanici doğrulanamadı";
                return RedirectToAction("Index");
            }
        }


        public IActionResult CerezOlustur()
        {
            CookieOptions cerezAyar = new CookieOptions();
            cerezAyar.Expires = DateTime.Now.AddMinutes(3);
            Response.Cookies.Append("BolumAdi","Yönetim Bilişim Sistemleri",cerezAyar);
            Response.Cookies.Append("Tarih", DateTime.Now.ToString(), cerezAyar);
            return RedirectToAction("Index");
        }
    }
}
