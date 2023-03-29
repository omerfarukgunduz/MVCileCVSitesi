using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCileCVSitesi.Models.Entity;

namespace MVCileCVSitesi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Hakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyimlerim()
        {
            var deneyimler = db.Tbl_Deneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.Tbl_SosyalMedya.Where(x=> x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.Tbl_Egitimlerim.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.Tbl_Yeteneklerim.ToList();
            return PartialView(yetenekler);
        } 
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.Tbl_Hobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult SertifikalarveOduller()
        {
            var sertifikaoduller = db.Tbl_Sertifikalarim.ToList();
            return PartialView(sertifikaoduller);

        }
        [HttpGet]
        public PartialViewResult İletisim()
        {
        return PartialView();
        }

        //İletişim bölümüne girilenleri veri tabanına kaydetme işlemi

        [HttpPost]
        public PartialViewResult İletisim(Tbl_iletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_iletisim.Add(t);
            db.SaveChanges();

            return PartialView();
        }
    }
}