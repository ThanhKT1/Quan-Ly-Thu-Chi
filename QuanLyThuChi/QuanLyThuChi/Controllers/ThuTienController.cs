using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThuChi.Models;

namespace QuanLyThuChi.Controllers
{
    public class ThuTienController : Controller
    {
        QuanLyThuChiEntities db = new QuanLyThuChiEntities();

        // GET: ThuTien
        public ActionResult ThuTiennn(ThuChiii thuchiii)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "DangKyDangNhap");
            }
            return View(db.ThuChiiis.ToList().Where(n => n.ThuChi == "Thu"));
        }
        
    }
}