using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThuChi.Models;
using System.IO;

namespace QuanLyThuChi.Controllers
{
    public class UserController : Controller
    {
        QuanLyThuChiEntities db = new QuanLyThuChiEntities();

        // GET: User
        public ActionResult Userr()
        {
            return View(db.Userrrs.ToList());
        }

        // Chỉnh sửa thông tin người dùng
        [HttpGet]
        public ActionResult ChinhSuaThongTin(int ID)
        {
            Userrr nguoidung = db.Userrrs.SingleOrDefault(n => n.ID == ID);
            if (nguoidung==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nguoidung);
        }
        [HttpPost]
        public  ActionResult ChinhSuaThongTin(Userrr nguoidung, FormCollection f)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoidung).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            return RedirectToAction("Userr","User");
        }
       
    }
}