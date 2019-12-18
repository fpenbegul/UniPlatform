using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniPlatform.Models;

namespace UniPlatform.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class DuyuruController : Controller
    {
        // GET: Admin/Duyuru
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {


            return View(db.Duyurular.ToList());
        }

        public ActionResult DuyuruDetay(int id)
        {

            Duyurular istenenDuyuru = db.Duyurular.Find(id);
            if (istenenDuyuru == null)
            {
                return HttpNotFound();
            }

            List<DuyuruYorumlar> yorumlar = db.DuyuruYorumlar.Where(x => x.DuyuruID == id).ToList();
            ViewBag.Yorumlar = yorumlar;

            string loogedUserID = User.Identity.GetUserId();
            if (loogedUserID != null)
            {

                ViewBag.KullaniciAdi = db.Users.Find(loogedUserID).UserName;
            }

            return View(istenenDuyuru);
        }
    }
}