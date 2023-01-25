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
            var values = db.TblHareket.Where(x => x.İslemDurum == false).ToList();
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
            var values = db.TblKitap.Find(tblHareket.Kitap);
            values.Durum = false;

            db.TblHareket.Add(tblHareket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Oduncİade(int id)
        {
            var odn = db.TblHareket.Find(id);
            odn.AlışTarih.Value.ToShortDateString();
            odn.İadeTarih.Value.ToShortDateString();
            return View("Oduncİade",odn);
        }
        [HttpPost]
        public ActionResult Oduncİade(TblHareket tblHareket)
        {
            var values = db.TblHareket.Find(tblHareket.Id);
            values.TblKitap.Durum = true;
            values.İslemDurum = true;
            values.ÜyeGetirTarih = tblHareket.ÜyeGetirTarih;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}