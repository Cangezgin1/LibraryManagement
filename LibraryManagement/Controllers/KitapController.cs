using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;

namespace LibraryManagement.Controllers
{
    public class KitapController : Controller
    {

        DbKütüphaneEntities db = new DbKütüphaneEntities();


        #region Kitap Listesi

        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TblKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.Ad.Contains(p));
            }
            //var kitaplar = db.TblKitap.ToList();
            return View(kitaplar.ToList());
        }

        #endregion

        #region Kitap Ekle

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.deger1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad+' '+i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.deger2 = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TblKitap tblKitap)
        {
            var ktg = db.TblKategori.Where(x => x.Id == tblKitap.TblKategori.Id).FirstOrDefault();
            var yzr = db.TblYazar.Where(x => x.Id == tblKitap.TblYazar.Id).FirstOrDefault();
            tblKitap.TblKategori = ktg;
            tblKitap.TblYazar = yzr;
            tblKitap.Durum = true;
            db.TblKitap.Add(tblKitap);
            db.SaveChanges();
            return RedirectToAction("Index","Kitap");
        }

        #endregion

        #region Kitap Sil

        public ActionResult KitapSil(int id)
        {
            var kitap = db.TblKitap.Find(id);
            db.TblKitap.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index", "Kitap");
        }

        #endregion

        #region Kitap Güncelleme

        public ActionResult KitapGetir(int id)
        {
            var values = db.TblKitap.Find(id);
            List<SelectListItem> deger1 = (from i in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.deger1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + ' ' + i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.deger2 = deger2;
            return View("KitapGetir", values);
        }
        public ActionResult KitapGüncelle(TblKitap tblKitap)
        {
            var kitap = db.TblKitap.Find(tblKitap.Id);
            kitap.Ad = tblKitap.Ad;
            kitap.BasımYıl = tblKitap.BasımYıl;
            kitap.SayfaSayısı = tblKitap.SayfaSayısı;
            kitap.YayınEvi = tblKitap.YayınEvi;
            var ktg = db.TblKategori.Where(x => x.Id == tblKitap.TblKategori.Id).FirstOrDefault();
            var yzr = db.TblYazar.Where(x => x.Id == tblKitap.TblYazar.Id).FirstOrDefault();
            kitap.Kategori = ktg.Id;
            kitap.Yazar = yzr.Id;
            kitap.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index","Kitap");
        }

        #endregion

    }
}