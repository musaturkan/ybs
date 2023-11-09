using Microsoft.AspNetCore.Mvc;

namespace Ornek1.Controllers
{
    public class UrunController : Controller
    {
        List<Models.Yorum> yorumListe = new List<Models.Yorum>
        {
            new Models.Yorum{Baslik="Ürün çok güzel",Metin="Kaliteli bir ürün tavsiye ederim"},
            new Models.Yorum{Baslik="Farklı ürün geldi",Metin="Firma dolandırıcı almayın"},
            new Models.Yorum{Baslik="Fotoğraftaki ürün geldi",Metin=" tavsiye ederim"}
        };

        List<Models.Urun> urunListe = new List<Models.Urun>
        {
            new Models.Urun{Id = 1000,Ad="Televizyon",Aciklama="Led tv",Fiyat=1587,
            ImageAdres="https://productimages.hepsiburada.net/s/428/550/110000459621183.jpg/format:webp"
          },
            
            new Models.Urun{Id = 1010,Ad="Kulaklık",Aciklama="Kulak içi kulaklık",Fiyat=5410,
            ImageAdres="https://productimages.hepsiburada.net/s/482/550/110000527574937.jpg/format:webp"
          },

            new Models.Urun{Id = 1020,Ad="Telefon",Aciklama="Akıllı telefon",Fiyat=2547,
            ImageAdres="https://productimages.hepsiburada.net/s/374/1100/110000391904798.jpg/format:webp"
          },
        };
        public IActionResult Index()
        {
            return View("AnaSayfa",urunListe);
        }

        public IActionResult UrunDetay(int id)
        {
            var urun = urunListe.FirstOrDefault(p => p.Id == id);
            urun.Yorum = yorumListe;

            ViewBag.Mesaj = "Oturum bilgileri bulunamadı";
            return View("UrunDetay", urun);
        }

        [HttpGet]
        public IActionResult UrunEkle()
        {
            return View("Yorum");
        }

        [HttpPost]
        public IActionResult UrunEkle(Models.Yorum yeniYorum)
        {
            yeniYorum.EklemeTarihi = DateTime.Now;
            return RedirectToAction("Index");   
        }

        /// <summary>
        /// Herhangi bir view partial view olarak döndürülmek istenirse PartialView metodu ile 
        /// döndürülür. Böylece safa view tasarımı elde edilmiş olur.
        /// Ajax isteklerinde partial view sıklıkla kullanılır.
        /// </summary>
        /// <returns></returns>
        public PartialViewResult UrunListePartial()
        {
            return PartialView("UrunDetay");
        }

        //IActionResult
        //PartialViewResult
        //ActionResult
        //FileResult
       
    }
}
