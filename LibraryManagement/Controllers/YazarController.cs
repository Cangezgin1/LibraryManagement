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



        #region Yazar Listeleme
        public ActionResult Index()
        {
            var values = db.TblYazar.ToList();
            return View(values);
        }
        #endregion

        #region Yazar Ekleme

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TblYazar tblYazar)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TblYazar.Add(tblYazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Yazar Silme

        public ActionResult YazarSil(int id)
        {
            var yazar = db.TblYazar.Find(id);
            db.TblYazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Yazar Güncelleme

        public ActionResult YazarGetir(int id)
        {
            var values = db.TblYazar.Find(id);
            return View("YazarGetir", values);
        }
        public ActionResult YazarGüncelle(TblYazar tblYazar)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarGetir");
            }
            var values = db.TblYazar.Find(tblYazar.Id);
            values.Ad = tblYazar.Ad;
            values.Soyad = tblYazar.Soyad;
            values.Detay = tblYazar.Detay;
            db.SaveChanges();
            return RedirectToAction("Index","Yazar");
        }
        #endregion


    }
}