using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ornek1.Controllers
{
    public class OturumController : Controller
    {
        public IActionResult Index()
        {
            var cerez = Request.Cookies["Tarih"];
            var userCerez=Request.Cookies["User"];

            if (cerez != null)
            {
                ViewBag.Tarih = cerez;
            }

            if(userCerez != null)
            {
                ViewBag.UserCerez = userCerez;
            }
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
                ///Claims based Authorization
                ///
                var claims = new List<Claim>();
                claims.Add(new Claim("Ad", oturumKullanici.Ad));
                claims.Add(new Claim("Soyad", oturumKullanici.Soyad));
                claims.Add(new Claim("KullaniciAdi", oturumKullanici.KullaniciAdi));
                claims.Add(new Claim("KayitTarihi", oturumKullanici.KayitTarihi.ToString()));


                var claimsKimlik = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authenticationProperties = new AuthenticationProperties
                {
                    //ExpiresUtc = DateTime.UtcNow,
                    //IsPersistent = true,
                    //RedirectUri = "";
                    
                };

               HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsKimlik), authenticationProperties);



                ///TODO:Otrurm çerez ayarları yapılacak


                //CookieOptions cerezAyar = new CookieOptions();
                //cerezAyar.Expires = DateTime.Now.AddMinutes(30);                
                /////Todo:Oturum çrezi şifrelenecek
                //Response.Cookies.Append("Oturum",oturumKullanici.KullaniciAdi,cerezAyar);
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

            Response.Cookies.Append("User", "ayse", cerezAyar);
            return RedirectToAction("Index");
        }
    }
}
