using Microsoft.AspNetCore.Mvc;
using DataModel.Market;

namespace Ornek1.ViewComponents
{
    public class MarkaViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(DataModel.Market.Urun urun)
        {
            ///View component kullanıldığı yerde çalışacak komutlar
            ///
            List<DataModel.Market.Marka> veriListesi = new();
            veriListesi.Add(new DataModel.Market.Marka { Ad = "Arçelik", Id = 10 } );
            veriListesi.Add(new DataModel.Market.Marka { Ad = "Beko", Id = 20 });
            veriListesi.Add(new DataModel.Market.Marka { Ad = "Vestel", Id = 30 });
            veriListesi.Add(new DataModel.Market.Marka { Ad = "Eti", Id = 40 });
            veriListesi.Add(new DataModel.Market.Marka { Ad = "Baykar", Id = 50 });

            return View("markaListe", veriListesi);
        }
    }
}
