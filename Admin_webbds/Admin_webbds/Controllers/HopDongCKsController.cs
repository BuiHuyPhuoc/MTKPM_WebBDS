using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admin_webbds.Models;

namespace Admin_webbds.Controllers
{
    public class HopDongCKsController : Controller
    {
        private BDS_TestEntities db = new BDS_TestEntities();

        // GET: HopDongCKs
        public ActionResult Index()
        {
            var hopDongCKs = db.HopDongCKs.Include(h => h.GiaoDich).Include(h => h.MoiGioi).Include(h => h.TaiKhoan);
            return View(hopDongCKs.ToList());
        }

        // GET: HopDongCKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDongCK hopDongCK = db.HopDongCKs.Find(id);
            if (hopDongCK == null)
            {
                return HttpNotFound();
            }
            return View(hopDongCK);
        }

        // GET: HopDongCKs/Create
        public ActionResult Create()
        {
            ViewBag.Ma_GD = new SelectList(db.GiaoDiches, "MaGiaoDich", "MaGiaoDich");
            ViewBag.MoiGioi_ID = new SelectList(db.MoiGiois, "MaDaiLy", "Ten");
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "ID", "TaiKhoan1");
            return View();
        }

        // POST: HopDongCKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaTK,MoiGioi_ID,Ma_GD,Ngay,ChietKhau")] HopDongCK hopDongCK)
        {
            if (ModelState.IsValid)
            {
                // Đặt giá trị mặc định cho các trường cần thiết
                hopDongCK.MaTK = 1; // Giá trị mã TK mặc định
                var giaoDich = db.GiaoDiches.Find(hopDongCK.Ma_GD);
                if (giaoDich != null)
                {
                    double gia = (double) giaoDich.Gia.Value;
                    hopDongCK.ChietKhau = gia * 0.1;
                }
                db.HopDongCKs.Add(hopDongCK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_GD = new SelectList(db.GiaoDiches, "MaGiaoDich", "MaGiaoDich", hopDongCK.Ma_GD);
            ViewBag.MoiGioi_ID = new SelectList(db.MoiGiois, "MaDaiLy", "Ten", hopDongCK.MoiGioi_ID);
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "ID", "TaiKhoan1", hopDongCK.MaTK);
            return View(hopDongCK);
        }

        // GET: HopDongCKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDongCK hopDongCK = db.HopDongCKs.Find(id);
            if (hopDongCK == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_GD = new SelectList(db.GiaoDiches, "MaGiaoDich", "MaGiaoDich", hopDongCK.Ma_GD);
            ViewBag.MoiGioi_ID = new SelectList(db.MoiGiois, "MaDaiLy", "Ten", hopDongCK.MoiGioi_ID);
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "ID", "TaiKhoan1", hopDongCK.MaTK);
            return View(hopDongCK);
        }

        // POST: HopDongCKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaTK,MoiGioi_ID,Ma_GD,Ngay,ChietKhau")] HopDongCK hopDongCK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hopDongCK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_GD = new SelectList(db.GiaoDiches, "MaGiaoDich", "MaGiaoDich", hopDongCK.Ma_GD);
            ViewBag.MoiGioi_ID = new SelectList(db.MoiGiois, "MaDaiLy", "Ten", hopDongCK.MoiGioi_ID);
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "ID", "TaiKhoan1", hopDongCK.MaTK);
            return View(hopDongCK);
        }

        // GET: HopDongCKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDongCK hopDongCK = db.HopDongCKs.Find(id);
            if (hopDongCK == null)
            {
                return HttpNotFound();
            }
            return View(hopDongCK);
        }

        // POST: HopDongCKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HopDongCK hopDongCK = db.HopDongCKs.Find(id);
            db.HopDongCKs.Remove(hopDongCK);
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
    }
}
