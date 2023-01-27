using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;
using LibraryManagement.Models.Sınıflarım;

namespace LibraryManagement.Controllers
{
    public class VitrinController : Controller
    {
        DbKütüphaneEntities db = new DbKütüphaneEntities();


        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TblKitap.ToList();
            cs.Deger2 = db.TblHakkımızda.ToList();

            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(Tblİletişim tblİletişim)
        {
            db.Tblİletişim.Add(tblİletişim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}