using GoogleAuthentication.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using webbds.Class;
using webbds.Models;
using Facebook;
namespace webbds.Controllers
{
    public class NguoiDungController : Controller
    {
        private BDS_TestEntities db = new BDS_TestEntities();
        SecretString_SingleTon singleTon = SecretString_SingleTon.GetInstance();
        // GET: NguoiDung
        public ActionResult Index()
        {
            var batDongSans = db.BatDongSans.Include(b => b.MoiGioi)
                              .Where(b => b.TrangThai == true)
                              .ToList();
            return View(batDongSans.ToList());
        }

        // GET: NguoiDung/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // GET: NguoiDung/Create
        public ActionResult Create()
        {
            // Set up for google authencation
            var clientId = SecretString_SingleTon.Google_ClientId;
            var url = "http://localhost:61552/NguoiDung/GoogleLoginCallBack";
            var respond = GoogleAuth.GetAuthUrl(clientId, url);
            ViewBag.Respond = respond;

            // Set up for facebook authencation
            var f_clientId = SecretString_SingleTon.Facebook_ClientId;
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = f_clientId,
                redirect_uri = "http://localhost:61552/NguoiDung/FacebookLoginCallBack",
                scope = "public_profile,email"
            });
            ViewBag.FacebookLoginUrl = loginUrl;
            return View();
        }

        // POST: NguoiDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNguoiDung,Ten,Email,DienThoai,DiaChi,Password")] NguoiDung nguoiDung, string submitButton)
        {
            if (submitButton == "Đăng ký")
            {
                var nguoiDungs = db.NguoiDungs.FirstOrDefault(k => k.Email == nguoiDung.Email);
                if (nguoiDungs != null)
                {
                    ModelState.AddModelError("CustomError", "Email này đã được đăng kí");
                    ViewBag.ms = "Email này đã được đăng kí";
                }
                if (ModelState.IsValid)
                {
                    // kiểm tra xem người ta có đăng ký với Email này chưa!
                    string kiemTraMatKhau = "";
                    PhuocPasswordValidation passwordValidation = new PhuocPasswordValidation();
                    kiemTraMatKhau = passwordValidation.ValidatePassword(nguoiDung.Password);
                    if (kiemTraMatKhau != "")
                    {
                        ModelState.AddModelError("CustomError", kiemTraMatKhau);
                        ViewBag.ms = kiemTraMatKhau;
                    }
                    if (ModelState.IsValid)
                    {
                        // Kiểm tra mật khẩu đã thoả các yêu cầu chưa
                        db.NguoiDungs.Add(nguoiDung);
                        db.SaveChanges();
                    }
                }
            }
            else if (submitButton == "Đăng nhập")
            {
                var nguoiDungLogin = db.NguoiDungs.FirstOrDefault(k => k.Email == nguoiDung.Email && k.Password == nguoiDung.Password);
                if (nguoiDungLogin != null)
                {
                    TempData["SuccessMessage"] = "Đăng nhập thành công!";
                    Session["TaiKhoan"] = nguoiDungLogin;
                    return RedirectToAction("Index", "NguoiDung");
                }
                else
                {
                    TempData["ErrorMessage"] = "Tên đăng nhập và mật khẩu không đúng!";
                    return View(nguoiDungLogin);
                }
            }
            return View(nguoiDung);
        }
        public ActionResult FacebookLoginCallBack(string code)
        {
            OtherLoginFactory otherLoginFactory = new FacebookLoginFactory();
            OtherLogin facebookLogin = otherLoginFactory.CreateLoginWay();
            User user = facebookLogin.GetUserByFacebook(code);
            if (facebookLogin.NguoiDung == null)
            {
                TempData["User"] = user;
                return RedirectToAction("CreateAccountByOtherLogin", "NguoiDung");
            }
            else
            {
                TempData["SuccessMessage"] = "Đăng nhập thành công!";
                Session["TaiKhoan"] = facebookLogin.NguoiDung;
                return RedirectToAction("Index", "NguoiDung");
            }
        }
        public async Task<ActionResult> GoogleLoginCallBack(string code)
        { 
            OtherLoginFactory otherLoginFactory = new GoogleLoginFactory();
            OtherLogin googleLogin = otherLoginFactory.CreateLoginWay();
            User user = await googleLogin.GetUserByGoogle(code);
            if (googleLogin.NguoiDung == null)
            {
                TempData["User"] = user;
                return RedirectToAction("CreateAccountByOtherLogin", "NguoiDung");
            } else
            {
                TempData["SuccessMessage"] = "Đăng nhập thành công!";
                Session["TaiKhoan"] = googleLogin.NguoiDung;
                return RedirectToAction("Index", "NguoiDung");
            }
        }

        public ActionResult CreateAccountByOtherLogin()
        {
            User user = TempData["User"] as User;
            return View(user);
        }

        // GET: NguoiDung/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // POST: NguoiDung/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNguoiDung,Ten,Email,DienThoai,DiaChi,Password")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiDung).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nguoiDung);
        }

        // GET: NguoiDung/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // POST: NguoiDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            db.NguoiDungs.Remove(nguoiDung);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Logout()
        {
            Session["MoiGioi"] = null;
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
