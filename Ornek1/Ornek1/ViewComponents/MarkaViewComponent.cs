using Microsoft.AspNetCore.Mvc;

namespace Ornek1.ViewComponents
{
    public class MarkaViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(Models.Urun urun)
        {
            ///View component kullanıldığı yerde çalışacak komutlar
            ///
            List<Models.Marka> veriListesi = new();
            veriListesi.Add(new Models.Marka { Ad = "Arçelik", Id = 10 } );
            veriListesi.Add(new Models.Marka { Ad = "Beko", Id = 20 });
            veriListesi.Add(new Models.Marka { Ad = "Vestel", Id = 30 });
            veriListesi.Add(new Models.Marka { Ad = "Eti", Id = 40 });
            veriListesi.Add(new Models.Marka { Ad = "Baykar", Id = 50 });

            return View("markaListe", veriListesi);
        }
    }
}
