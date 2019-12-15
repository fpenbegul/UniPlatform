using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UniPlatform.Models;

namespace UniPlatform.Controllers
{
    [Authorize(Roles = "user")]
    public class DuyuruController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Duyuru
        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(Duyurular duyuru)
        {
            string loogedUserID = User.Identity.GetUserId();

            string mesaj;
            if (true) // yeni kayıt...
            {
                Duyurular d = new Duyurular();
                d.DuyuranId = loogedUserID;
                d.DuyruBaslik = duyuru.DuyruBaslik;
                d.Icerik = duyuru.Icerik;
                d.DuyuruTarihi = DateTime.Now;
                d.OnayliMi = false;
                db.Duyurular.Add(d);
                db.SaveChanges();

                int duyuru_id = d.ID;
                mesaj = "Eklendi (" + d.DuyuruTarihi.ToLongDateString() + " tarihinde "+d.ID +". id ile kaydedildi!)";

            }


            return Json(mesaj);
        }
    }
}