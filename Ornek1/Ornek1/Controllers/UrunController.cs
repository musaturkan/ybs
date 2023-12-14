using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ornek1.Attributes;
using DataModel.Market;

namespace Ornek1.Controllers
{
    [Log]
    [Hata]
    [Kontrol]
    public class UrunController : Controller
    {
        List<Yorum> yorumListe = new List<Yorum>
        {
            new Yorum{Baslik="Ürün çok güzel",Metin="Kaliteli bir ürün tavsiye ederim"},
            new Yorum{Baslik="Farklı ürün geldi",Metin="Firma dolandırıcı almayın"},
            new Yorum{Baslik="Fotoğraftaki ürün geldi",Metin=" tavsiye ederim"}
        };

        //List<Models.Urun> urunListe = new List<Models.Urun>
        //{
        //    new Models.Urun{Id = 1000,Ad="Televizyon",Aciklama="Led tv",Fiyat=1587,
        //    ImageAdres="https://productimages.hepsiburada.net/s/428/550/110000459621183.jpg/format:webp"
        //  },
            
        //    new Models.Urun{Id = 1010,Ad="Kulaklık",Aciklama="Kulak içi kulaklık",Fiyat=5410,
        //    ImageAdres="https://productimages.hepsiburada.net/s/482/550/110000527574937.jpg/format:webp"
        //  },

        //    new Models.Urun{Id = 1020,Ad="Telefon",Aciklama="Akıllı telefon",Fiyat=2547,
        //    ImageAdres="https://productimages.hepsiburada.net/s/374/1100/110000391904798.jpg/format:webp"
        //  },
        //};

        public IActionResult Index()
        {
            ///Entity model nesnesi oluşturulur. Context sınıfı kullanılır
            ///
            MarketContext model=new MarketContext();
            List<Urun> urunListesi = model.Urun
                                            .Include(m=>m.Marka)
                                            .Include(y=>y.Yorum)
                                            .ThenInclude(k=>k.Kullanici)
                                            //.Include("Yorum.Kullanici")
                                            .ToList();

            var tarihCerez = Request.Cookies["Tarih"];

            if (tarihCerez != null)
            {
                ViewBag.GirisTarihi = tarihCerez;
            }

            return View("AnaSayfa", urunListesi);
        }

        //[Log]
        //[Kontrol]
        [Route("Urun/{id:int=8}")]
        public IActionResult UrunDetay(int id)
        {
            //var urun = urunListe.FirstOrDefault(p => p.Id == id);
            //urun.Yorum = yorumListe;
            //ViewBag.Mesaj = "Oturum bilgileri bulunamadı";
            MarketContext model = new MarketContext();
            ///Tek bir ürün kaydını Urun cinsinden bir nesne olarak elde etme
            var urun=model.Urun
                    .Include("Yorum.Kullanici")
                    .Include(m=>m.Marka)
                    .FirstOrDefault(p=>p.Id==id);

            ///Birden fazla ürün kaydını Urün listesi olarak elde etme
            var ikinciListe = model.Urun.Where(u => u.Fiyat > 2000).ToList();

            return View("UrunDetay",urun);
        }

        [HttpGet]
        //[Log]
        public IActionResult UrunEkle()
        {
            MarketContext model = new MarketContext();
            var markaListesi = model.Marka.ToList();

            return View("UrunEkle",markaListesi);
        }

        [HttpPost]
        public IActionResult UrunEkle(Urun yeniUrun)
        {
            MarketContext model = new MarketContext();
            model.Urun.Add(yeniUrun);
            model.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult YorumEkle(Yorum yeniYorum)
        {
            yeniYorum.EklemeTarihi = DateTime.Now;

            MarketContext model = new MarketContext();
            model.Yorum.Add(yeniYorum);

            model.SaveChanges();

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
