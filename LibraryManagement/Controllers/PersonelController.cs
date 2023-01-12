using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;

namespace LibraryManagement.Controllers
{
    public class PersonelController : Controller
    {

        DbKütüphaneEntities db = new DbKütüphaneEntities();


        #region Personel Listesi

        public ActionResult Index()
        {
            var values = db.TblPersonel.ToList();
            return View(values);
        }

        #endregion

        #region Personel Ekle

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TblPersonel tblPersonel)
        {
            if (!ModelState.IsValid)
                return View("PersonelEkle");

            db.TblPersonel.Add(tblPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Personel Sil

        public ActionResult PersonelSil(int id)
        {
            var values = db.TblPersonel.Find(id);
            db.TblPersonel.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Personel Güncelleme

        public ActionResult PersonelGetir(int id)
        {
            var values = db.TblPersonel.Find(id);
            return View("PersonelGetir", values);
        }
        public ActionResult PersonelGüncelle(TblPersonel tblPersonel)
        {
            if (!ModelState.IsValid)
                return View("PersonelGetir");

            var values = db.TblPersonel.Find(tblPersonel.Id);
            values.Personel = tblPersonel.Personel;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
    }
}