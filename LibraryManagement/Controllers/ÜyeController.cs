using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace LibraryManagement.Controllers
{
    public class ÜyeController : Controller
    {
        DbKütüphaneEntities db = new DbKütüphaneEntities();


        #region Üye Listeleme

        public ActionResult Index(int sayfa = 1)
        {
            var values = db.TblUyeler.ToList().ToPagedList(sayfa,3);
            return View(values);
        }

        #endregion

        #region Üye Ekleme

        [HttpGet]
        public ActionResult ÜyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ÜyeEkle(TblUyeler tblUyeler)
        {
            if (!ModelState.IsValid)
            {
                return View("ÜyeEkle");
            }
            db.TblUyeler.Add(tblUyeler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Üye Silme

        public ActionResult ÜyeSil(int id)
        {
            var values = db.TblUyeler.Find(id);
            db.TblUyeler.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Üye Güncelleme

        [HttpGet]
        public ActionResult ÜyeGetir(int id)
        {
            var values = db.TblUyeler.Find(id);
            return View("ÜyeGetir",values);
        }
        [HttpPost]
        public ActionResult ÜyeGüncelle(TblUyeler tblUyeler)
        {
            if (!ModelState.IsValid)
                return View("ÜyeGetir");

            var üye = db.TblUyeler.Find(tblUyeler.Id);
            üye.Ad = tblUyeler.Ad;
            üye.Soyad = tblUyeler.Soyad;
            üye.Mail = tblUyeler.Mail;
            üye.KullanıcıAdı = tblUyeler.KullanıcıAdı;
            üye.Sifre = tblUyeler.Sifre;
            üye.Okul = tblUyeler.Okul;
            üye.TelefonNo = tblUyeler.TelefonNo;
            üye.Fotoğraf = tblUyeler.Fotoğraf;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
    }
}