using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCileCVSitesi.Models.Entity;
using MVCileCVSitesi.Controllers;
using MVCileCVSitesi.Repositories;

namespace MVCileCVSitesi.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<Tbl_iletisim> repo = new GenericRepository<Tbl_iletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }

        public ActionResult mesajsil(int id)
        {
            Tbl_iletisim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return (RedirectToAction("Index"));
        }
    }
}