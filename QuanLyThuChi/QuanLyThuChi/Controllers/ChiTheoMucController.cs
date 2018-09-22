using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThuChi.Models;

namespace QuanLyThuChi.Controllers
{
    public class ChiTheoMucController : Controller
    {
        QuanLyThuChiEntities db = new QuanLyThuChiEntities();

        // GET: ChiTheoMuc
        public ActionResult Index(MucChi mucchi)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "DangKyDangNhap");
            }
            return View(db.MucChis.ToList());
        }
        public ActionResult ChiTheoMuc(string TenMuc)
        {
           
            return View(db.ThuChiiis.ToList().Where(n=>n.TenMuc == TenMuc));
        }
    }
}