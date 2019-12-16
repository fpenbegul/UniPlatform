using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniPlatform.Models;

namespace UniPlatform.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<Duyurular> duyurular = db.Duyurular.Where(x => x.OnayliMi == true).Take(10).OrderByDescending(x => x.ID).ToList();
            ViewBag.duyurular = duyurular;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "user")]
        public ActionResult DuyuruEkle()
        {
            return View();
        }

        public ActionResult DuyuruDetay(int id)
        {

            Duyurular istenenDuyuru = db.Duyurular.Find(id);
            if (istenenDuyuru == null)
            {
                return HttpNotFound();
            }

            return View(istenenDuyuru);
        }


    }
}