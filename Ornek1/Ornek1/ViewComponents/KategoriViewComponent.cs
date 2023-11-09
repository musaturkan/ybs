using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ornek1.ViewComponents;

/// <summary>
/// Bir sınıf view component olması için aşağıdakilerden birisi uygulanır
/// -ViewComponent sınıfından türetilerek oluşturulan sınıflar view component olur
/// -ViewComponent attribute ile bildirilen sınıflar
/// -sınıf adının sonunda ViewComponent bulunan sınıflar
/// -Yukardakilerden birisi ile birlikte sınıf Invoke metoduna sahip olmalıdır.
/// -Invoke medotu geri dönüş tipi IViewComponentResult tipinde olmalıdır
/// </summary>

   //[ViewComponent]
    public class KategoriViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<Models.Kategori> liste = new();
            //liste.Add(new Models.Kategori { Id = 1, Ad = "Elektronik", KisaAd = "El" });
            //liste.Add(new Models.Kategori { Id = 2, Ad = "Mobilya", KisaAd = "Mob" });
            //liste.Add(new Models.Kategori { Id = 3, Ad = "Tekstil", KisaAd = "Tks" });
            //liste.Add(new Models.Kategori { Id = 4, Ad = "Spor", KisaAd = "Spr" });
            Models.MarketContext model = new Models.MarketContext();
            liste = model.Kategori.ToList();


            return View("kategoriListe",liste);
        } 
    }
