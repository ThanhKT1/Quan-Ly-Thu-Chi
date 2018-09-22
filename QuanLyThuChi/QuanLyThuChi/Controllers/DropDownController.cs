using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThuChi.Models;

namespace QuanLyThuChi.Controllers
{
    public class DropDownController : Controller
    {
        QuanLyThuChiEntities db = new QuanLyThuChiEntities();
        // GET: DropDown

        public ActionResult ListMuc()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "DangKyDangNhap");
            }
            return View(db.MucChis.ToList());
        }

        [HttpGet]
        public ActionResult ThemMuc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMuc(MucChi mucchi)
        {
            if (ModelState.IsValid)
            {
                db.MucChis.Add(mucchi);
                db.SaveChanges();
                ViewBag.ThongBao = "Đã thêm mục thành công";
                return RedirectToAction("ThemMuc", "DropDown");
            }
            return View();
        }

        //Chỉnh sửa
        [HttpGet]
        public ActionResult ChinhSua(int MaMuc)
        {
            MucChi mucchi = db.MucChis.SingleOrDefault(n => n.MaMuc == MaMuc);
            if (mucchi == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(mucchi);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(MucChi mucchi,FormCollection f)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mucchi).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.ThongBao = "Lưu lại thành công";
            }
            return View(mucchi);
        }


        //Xóa
        [HttpGet]
        public ActionResult XoaMuc(int MaMuc)
        {
            MucChi mucchitieu = db.MucChis.SingleOrDefault(n => n.MaMuc == MaMuc);
            if (mucchitieu==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(mucchitieu);
        }
        [HttpPost,ActionName("XoaMuc")]
        [ValidateInput(false)]
        public ActionResult XoaMucChi(int MaMuc)
        {
            MucChi mucchitieu = db.MucChis.SingleOrDefault(n => n.MaMuc == MaMuc);
            if (mucchitieu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.MucChis.Remove(mucchitieu);
            db.SaveChanges();
            return RedirectToAction("ListMuc","DropDown");
        }


    }
}