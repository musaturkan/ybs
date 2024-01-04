using Microsoft.AspNetCore.Mvc;
using Kutuphane.Oyun1;
using Kutuphane;

namespace Ornek1.Controllers
{
    public class AracController : Controller
    {
        private readonly ILog _log;
        private readonly IArac _arac;

        public AracController(ILog log)
        {
            _log = log;
           // _arac = arac;
        }

        public IActionResult AracKullan()
        {
            Surucu surucu = new Surucu();
            surucu.Arac = new Otomobil();
            surucu.Arac = new Tank();
            //surucu.Otomobil = new Otomobil();
            //surucu.Otomobil.Calistir();

            //surucu.Tank=new Tank();
            _arac.Calistir();

            List<IArac> liste=new List<IArac>();

            liste.Add(new Otomobil());
            liste.Add(new Tank());
            liste.Add(new Kamyon());


            foreach (var arac in liste)
            {
                arac.Calistir();                    
            }

            return View();
        }

        public IActionResult Index([FromServices]IArac arac)
        {
            arac.HareketEt();
            //TextLog log=new TextLog();
            _log.Log();

            return View();
        }
    }
}
