using Microsoft.AspNetCore.Mvc;
using Kutuphane.Oyun1;
using Kutuphane;

namespace Ornek1.Controllers
{
    public class AracController : Controller
    {
     
        ILog _log;
        IArac _arac;
       
        public AracController(ILog log, IArac arac)
        {
            _log = log;
            _arac = arac;
          
         }

        public IActionResult AracKullan([FromServices]IArac arac)
        {
            arac.HareketEt();
            _log.Log();

            Surucu surucu = new Surucu();
            surucu.Arac = new Otomobil();
            surucu.Arac.HareketEt();
            surucu.Arac.Durdur();

            surucu.Arac = new Tank();
            surucu.Arac.Calistir();

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
            _log.Log();
           // LogYonetim log = new LogYonetim(new VeritabaniLog());
            //VeritabaniLog log = new VeritabaniLog();
            //log.LogYaz();

            arac.HareketEt();
            //TextLog log=new TextLog();
            _log.Log();

            return View();
        }
    }
}
