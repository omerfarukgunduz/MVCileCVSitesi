using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCileCVSitesi.Models.Entity;
using MVCileCVSitesi.Repositories;

namespace MVCileCVSitesi.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<Tbl_SosyalMedya> repo = new GenericRepository<Tbl_SosyalMedya>();

        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Tbl_SosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }

        [HttpPost]
        public ActionResult SayfaGetir(Tbl_SosyalMedya p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);
            hesap.Durum = true;
            hesap.Ad = p.Ad;
            hesap.Link = p.Link;
            hesap.ikon = p.ikon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}