using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;

namespace LibraryManagement.Controllers
{
    public class OduncController : Controller
    {

        DbKütüphaneEntities db = new DbKütüphaneEntities();


        public ActionResult Index()
        {
            var values = db.TblHareket.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TblHareket tblHareket)
        {
            db.TblHareket.Add(tblHareket);
            db.SaveChanges();
            return View();
        }
    }
}