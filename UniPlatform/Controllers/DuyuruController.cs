using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using UniPlatform.Models;

namespace UniPlatform.Controllers
{
    [Authorize(Roles = "user")]
    public class DuyuruController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Duyuru
        public HttpResponseMessage DuyuruEkle()
        {

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Save(Duyurular duyuru)
        {
            string loogedUserID = User.Identity.GetUserId();

            string mesaj;
            if (true) // yeni kayıt...
            {
                Duyurular d = new Duyurular();
                d.DuyuranId = loogedUserID;
                d.DuyuruBaslik = duyuru.DuyuruBaslik;
                d.Icerik = duyuru.Icerik;
                d.DuyuruTarihi = DateTime.Now;
                d.OnayliMi = true;
                db.Duyurular.Add(d);
                db.SaveChanges();

                int duyuru_id = d.ID;
                mesaj = "Duyuru eklendi!";

            }


            return Request.CreateResponse(mesaj);
        }


    }
}
