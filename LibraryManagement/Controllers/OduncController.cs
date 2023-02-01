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
        public ActionResult Oduncİade(TblHareket tblHareket)
        {
            var odn = db.TblHareket.Find(tblHareket.Id);
            DateTime d1 = DateTime.Parse(odn.İadeTarih.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            odn.AlışTarih.Value.ToShortDateString();
            odn.İadeTarih.Value.ToShortDateString();
            return View("Oduncİade",odn);
        }

        [HttpPost]
        public ActionResult OduncGuncelle(TblHareket tblHareket)
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