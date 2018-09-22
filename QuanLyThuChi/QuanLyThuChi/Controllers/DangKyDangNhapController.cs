using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThuChi.Models;

namespace QuanLyThuChi.Controllers
{
    public class DangKyDangNhapController : Controller
    {
        QuanLyThuChiEntities db = new QuanLyThuChiEntities();
        // GET: DangKyDangNhap
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(Userrr user)
        {
            if (ModelState.IsValid)
            {
                db.Userrrs.Add(user);
                db.SaveChanges();
                return RedirectToAction("DangNhap", "DangKyDangNhap");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();

            Userrr user = db.Userrrs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (user != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                Session["TaiKhoan"] = user;
                return RedirectToAction("QuanLyThuChiii", "QuanLyThuCHi");
            }
            ViewBag.ThongBao = "Sai tài khoản hoặc mật khẩu !";
            return View(user);
        }
    }
}