using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniPlatform.Models;
using PagedList;


namespace UniPlatform.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<Duyurular> duyurular = db.Duyurular.Where(x => x.OnayliMi == true).Take(10).OrderByDescending(x => x.ID).ToList();
            List<Ilanlar> ilanlar = db.Ilanlar.Where(x => x.OnayliMi == true).Take(10).OrderByDescending(x => x.ID).ToList();
            
            ViewBag.duyurular = duyurular;
            ViewBag.ilanlar = ilanlar;

            return View();
        }
        [Authorize(Roles = "user")]
        public ActionResult IlanEkle()
        {
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

            List<DuyuruYorumlar> yorumlar = db.DuyuruYorumlar.Where(x => x.DuyuruID == id).ToList();
            ViewBag.Yorumlar = yorumlar;

            string loogedUserID = User.Identity.GetUserId();
            if (loogedUserID != null)
            {

                ViewBag.KullaniciAdi = db.Users.Find(loogedUserID).UserName;
            }

            return View(istenenDuyuru);
        }
        public ActionResult ButunDuyurular(int? page)
        {
            List<Duyurular> duyurular = new List<Duyurular>();
            //duyurular = db.Duyurular.ToList().ToPagedList(page ?? 1, 2);

            duyurular = db.Duyurular.OrderByDescending(x => x.ID).ToList();

            return View(duyurular);
        }
        
        public ActionResult IlanDetay(int id)
        {

            Ilanlar istenenIlan = db.Ilanlar.Find(id);
            if (istenenIlan == null)
            {
                return HttpNotFound();
            }

            List<IlanYorumlar> yorumlar = db.IlanYorumlar.Where(x => x.IlanID == id).ToList();
            ViewBag.Yorumlar = yorumlar;

            string loogedUserID = User.Identity.GetUserId();
            if (loogedUserID != null)
            {
                ViewBag.KullaniciAdi = db.Users.Find(loogedUserID).UserName;
            }

            return View(istenenIlan);
        }



    }
}