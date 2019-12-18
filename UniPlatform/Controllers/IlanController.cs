using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UniPlatform.Models;

namespace UniPlatform.Controllers
{
    [Authorize(Roles = "user")]
    public class IlanController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public HttpResponseMessage IlanEkle()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Save(Ilanlar ilan)
        {
            string loogedUserID = User.Identity.GetUserId();
            string mesaj;

            Ilanlar i = new Ilanlar();
            i.IlanSahibiId = loogedUserID;
            i.IlanBaslik = ilan.IlanBaslik;
            i.Icerik = ilan.Icerik;
            i.IlanTarihi = DateTime.Now;
            i.OnayliMi = true;
            db.Ilanlar.Add(i);
            db.SaveChanges();

            int duyuru_id = i.ID;
            mesaj = "Duyuru eklendi!";

            return Request.CreateResponse(mesaj);
        }

        [HttpPost]
        public HttpResponseMessage YorumEkle(DuyuruYorumlar gelen_yorum)
        {
            string loogedUserID = User.Identity.GetUserId();
            string kullanici_adi = db.Users.Find(loogedUserID).UserName;

            string mesaj;

            DuyuruYorumlar yorum = new DuyuruYorumlar();
            yorum.YorumIcerik = gelen_yorum.YorumIcerik + "<br> <strong>" + kullanici_adi + "</strong> -" + DateTime.Now;
            yorum.DuyuruID = gelen_yorum.DuyuruID;

            db.DuyuruYorumlar.Add(yorum);
            db.SaveChanges();

            mesaj = "Duyuru eklendi!";


            return Request.CreateResponse(mesaj);
        }


    }
}
