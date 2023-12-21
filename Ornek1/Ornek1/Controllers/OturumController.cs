using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ornek1.Attributes;
using System.Security.Claims;
using System.Text.Json;

namespace Ornek1.Controllers
{
    [Hata]
    [Log]
    public class OturumController : Controller
    {
        public IActionResult Index()
        {
            var cerez = Request.Cookies["Tarih"];
            var userCerez=Request.Cookies["User"];
            HttpContext.SignOutAsync();

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


        public IActionResult Cikis()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult OturumAc(Models.Oturum_VM kullanici)
        {
            DataModel.Market.MarketContext model = new DataModel.Market.MarketContext();
            var oturumKullanici=model.Kullanici.FirstOrDefault(k=>k.KullaniciAdi==kullanici.KullaniciAdi && k.Parola==kullanici.Parola);
            if (oturumKullanici != null)
            {
                string jsonKullanici= JsonSerializer.Serialize(oturumKullanici);

                ///Claims based Authorization
                ///Claim nesne listesi oluşturularak saklanmak istenen oturum verileri bu listeye anahtar değer çifti olarak eklenebilri
                var claims = new List<Claim>();

                claims.Add(new Claim("Id", oturumKullanici.Id.ToString()));
                claims.Add(new Claim("Ad", oturumKullanici.Ad));
                claims.Add(new Claim("Soyad", oturumKullanici.Soyad));
                claims.Add(new Claim("KullaniciAdi", oturumKullanici.KullaniciAdi));
                claims.Add(new Claim("KayitTarihi", oturumKullanici.KayitTarihi.ToString()));
                claims.Add(new Claim("JsonKullanici",jsonKullanici));

                ///ClaimsIdentiy nesnesi yukarıdaki claims listesi ile oluşturulur
                var claimsKimlik = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                
                var authenticationProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddDays(1),
                    //IsPersistent = true,
                    //RedirectUri = "";
                   
                };
              
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsKimlik), authenticationProperties);


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

        /// <summary>
        /// İçeriği açık olan bir çerez oluşturma
        /// </summary>
        /// <returns></returns>
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
