using LibraryManagement.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class YazarController : Controller
    {

        DbKütüphaneEntities db = new DbKütüphaneEntities();


        public ActionResult Index()
        {
            var values = db.TblYazar.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TblYazar tblYazar)
        {
            db.TblYazar.Add(tblYazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        public ActionResult YazarSil(int id)
        {
            var yazar = db.TblYazar.Find(id);
            db.TblYazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        public ActionResult YazarGetir(int id)
        {
            var values = db.TblYazar.Find(id);
            return View("YazarGetir", values);
        }
        public ActionResult YazarGüncelle(TblYazar tblYazar)
        {
            var values = db.TblYazar.Find(tblYazar.Id);
            values.Ad = tblYazar.Ad;
            values.Soyad = tblYazar.Soyad;
            values.Detay = tblYazar.Detay;
            db.SaveChanges();
            return RedirectToAction("Index","Yazar");
        }

    }
}