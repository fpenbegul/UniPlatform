using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniPlatform.Models;

namespace UniPlatform.Areas.Admin.Controllers
{
    public class PanelController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Panel
        public ActionResult Index()
        {
            List<Duyurular> model = db.Duyurular.OrderByDescending(x => x.ID).ToList();
            return View(model);
        }
    }
}