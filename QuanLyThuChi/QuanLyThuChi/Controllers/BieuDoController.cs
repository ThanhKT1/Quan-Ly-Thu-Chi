using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThuChi.Models;

namespace QuanLyThuChi.Controllers
{
    public class BieuDoController : Controller
    {
        QuanLyThuChiEntities db = new QuanLyThuChiEntities();

        // GET: BieuDo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            var thu = db.ThuChiiis.Where(x => x.ThuChi == "Thu").Count();
            var chi = db.ThuChiiis.Where(x => x.ThuChi == "Chi").Count();
        
            ThuChiii thuchiii = new ThuChiii();
            thuchiii.Thu = thu;
            thuchiii.Chi = chi;
            return Json(thuchiii, JsonRequestBehavior.AllowGet);
        }
        public class ThuChiii
        {
            public int Thu { get; set; }
            public int Chi { get; set; }
        }
    }
}