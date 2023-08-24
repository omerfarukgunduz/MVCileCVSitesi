using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCileCVSitesi.Models.Entity;
using MVCileCVSitesi.Repositories;

namespace MVCileCVSitesi.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<Tbl_Hobilerim> repo = new GenericRepository<Tbl_Hobilerim>();
       [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hobilerim p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        public ActionResult HobiEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HobiEkle(Tbl_Hobilerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("HobiDuzenle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult HobiSil(int id)
        {
            Tbl_Hobilerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return (RedirectToAction("Index"));
        }

        public ActionResult HobiDuzenle(int id)
        {
            var hobi = repo.Find(x => x.ID == id);
            return View(hobi);
        }
        [HttpPost]
        public ActionResult HobiDuzenle(Tbl_Hobilerim t)
        {
            var hobi = repo.Find(x => x.ID == t.ID);
            hobi.Aciklama1 = t.Aciklama1;
            hobi.Aciklama2 = t.Aciklama2;
            repo.TUpdate(hobi);
            return RedirectToAction("Index");
        }
    }
}