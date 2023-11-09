using Microsoft.AspNetCore.Mvc;

namespace Ornek1.ViewComponents;

    public class KategoriViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<Models.Kategori> liste = new();
            liste.Add(new Models.Kategori { Id = 1, Ad = "Elektronik", KisaAd = "El" });
            liste.Add(new Models.Kategori { Id = 2, Ad = "Mobilya", KisaAd = "Mob" });
            liste.Add(new Models.Kategori { Id = 3, Ad = "Tekstil", KisaAd = "Tks" });
            liste.Add(new Models.Kategori { Id = 4, Ad = "Spor", KisaAd = "Spr" });
            

            return View("kategoriListe",liste);
        } 
    }
