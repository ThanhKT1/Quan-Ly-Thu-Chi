using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThuChi.Models;
using PagedList;
using PagedList.Mvc;


namespace QuanLyThuChi.Controllers
{

    public class QuanLyThuCHiController : Controller
    {
        

        QuanLyThuChiEntities db = new QuanLyThuChiEntities();
        // GET: QuanLyThuCHi
        
        
          
        public ActionResult QuanLyThuChiii(int?page)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "DangKyDangNhap");
            }

            DateTime now = DateTime.Now;
          
                int pageSize = 5;
                int pageNumber = page ?? 1;

            ViewBag.NgayGio = now;
            ViewBag.ChuDe = new SelectList(db.MucChis.ToList(), "MaMuc", "TenMuc");

            return View(db.ThuChiiis.ToList().ToPagedList(pageNumber,pageSize));
        }

      

        [HttpGet]
        public ActionResult ThemMoiii()
        {
            ViewBag.ChuDe = new SelectList(db.MucChis.ToList(), "MaMuc", "TenMuc");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoiii(ThuChiii thuchiii)
        {
            ViewBag.ChuDe = new SelectList(db.MucChis.ToList(), "MaMuc", "TenMuc");
            if (ModelState.IsValid)
            {
                db.ThuChiiis.Add(thuchiii);
                db.SaveChanges();
                return RedirectToAction("QuanLyThuChiii");
            }
            return View();
        }

        //Chi tiết 
        [HttpGet]
        public ActionResult ChinhSuaaa(int IDD)
        {
            ThuChiii thuchiii = db.ThuChiiis.SingleOrDefault(n => n.ID == IDD);
            if (thuchiii == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.ChuDe = new SelectList(db.MucChis.ToList(), "MaMuc", "TenMuc");

            return View(thuchiii);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSuaaa(ThuChiii thuchiii, FormCollection f)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuchiii).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            ViewBag.ChuDe = new SelectList(db.MucChis.ToList(), "MaMuc", "TenMuc");
            ViewBag.ThongBao = "Lưu lại thành công ";
            return View(thuchiii);
        }

        //Chi tiết
        public ActionResult HienThiii(int IDD)
        {
            ThuChiii thuchiii = db.ThuChiiis.SingleOrDefault(n => n.ID == IDD);
            if (thuchiii == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(thuchiii);
        }

        // Xóa
        [HttpGet]
        public ActionResult Xoaaa(int IDD)
        {
            ThuChiii thuchiii = db.ThuChiiis.SingleOrDefault(n => n.ID == IDD);
            if (thuchiii == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(thuchiii);
        }
        [HttpPost, ActionName("Xoaaa")]
        [ValidateInput(false)]
        public ActionResult XacNhanXoaaa(int IDD)
        {
            ThuChiii thuchiii = db.ThuChiiis.SingleOrDefault(n => n.ID == IDD);
            if (thuchiii == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ThuChiiis.Remove(thuchiii);
            db.SaveChanges();
            return RedirectToAction("QuanLyThuChiii", "QuanLyThuCHi");
        }       
    }
}