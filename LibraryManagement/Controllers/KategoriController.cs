﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;

namespace LibraryManagement.Controllers
{
    public class KategoriController : Controller
    {

        DbKütüphaneEntities db = new DbKütüphaneEntities();

        #region Kategori Listeleme

        public ActionResult Index()
        {
            var values = db.TblKategori.ToList();
            return View(values);
        }

        #endregion

        #region Kategori Ekleme

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TblKategori tblKategori)
        {
            db.TblKategori.Add(tblKategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Kategori Silme

        public ActionResult KategoriSil(int id)
        {
            var values = db.TblKategori.Find(id);
            db.TblKategori.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Kategori Güncelleme

        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TblKategori.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGüncelle(TblKategori tblKategori)
        {
            var values = db.TblKategori.Find(tblKategori.Id);
            values.Ad = tblKategori.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

    }
}