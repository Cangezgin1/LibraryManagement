using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models.Entity;

namespace LibraryManagement.Controllers
{
    public class İslemController : Controller
    {
        DbKütüphaneEntities db = new DbKütüphaneEntities();

        public ActionResult Index()
        {
            var values = db.TblHareket.Where(x => x.İslemDurum == true).ToList();
            return View(values);
        }
    }
}