using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admin_webbds.Models;

namespace Admin_webbds.Controllers
{
    public class GiaoDicheController : Controller
    {
        private BDS_TestEntities db = new BDS_TestEntities();

        // GET: GiaoDiche
        public ActionResult Index()
        {
            var giaoDiches = db.GiaoDiches.Include(g => g.BatDongSan).Include(g => g.NguoiDung).Include(g => g.MoiGioi);
            return View(giaoDiches.ToList());
        }

        // GET: GiaoDiche/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoDich giaoDich = db.GiaoDiches.Find(id);
            if (giaoDich == null)
            {
                return HttpNotFound();
            }
            return View(giaoDich);
        }

        // GET: GiaoDiche/Create
        public ActionResult Create()
        {
            ViewBag.MaBatDongSan = new SelectList(db.BatDongSans, "MaBatDongSan", "TieuDe");
            ViewBag.MaNguoiBan = new SelectList(db.NguoiDungs, "MaNguoiDung", "Ten");
            ViewBag.MaNguoiBan = new SelectList(db.MoiGiois, "MaDaiLy", "Ten");
            return View();
        }

        // POST: GiaoDiche/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBatDongSan,MaNguoiMua,MaNguoiBan,NgayGiaoDich")] GiaoDich giaoDich)
        {
            if (ModelState.IsValid)
            {
                var batDongSan = db.BatDongSans.Find(giaoDich.MaBatDongSan);

                if (batDongSan != null)
                {
                    giaoDich.Gia = batDongSan.Gia;
                }

                db.GiaoDiches.Add(giaoDich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBatDongSan = new SelectList(db.BatDongSans, "MaBatDongSan", "TieuDe", giaoDich.MaBatDongSan);
            ViewBag.MaNguoiMua = new SelectList(db.NguoiDungs, "MaNguoiDung", "Ten", giaoDich.MaNguoiMua);
            ViewBag.MaNguoiBan = new SelectList(db.MoiGiois, "MaDaiLy", "Ten", giaoDich.MaNguoiBan);
            return View(giaoDich);
        }

        // GET: GiaoDiche/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoDich giaoDich = db.GiaoDiches.Find(id);
            if (giaoDich == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBatDongSan = new SelectList(db.BatDongSans, "MaBatDongSan", "TieuDe", giaoDich.MaBatDongSan);
            ViewBag.MaNguoiBan = new SelectList(db.NguoiDungs, "MaNguoiDung", "Ten", giaoDich.MaNguoiBan);
            ViewBag.MaNguoiBan = new SelectList(db.MoiGiois, "MaDaiLy", "Ten", giaoDich.MaNguoiBan);
            return View(giaoDich);
        }

        // POST: GiaoDiche/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGiaoDich,MaBatDongSan,MaNguoiMua,MaNguoiBan,NgayGiaoDich,Gia")] GiaoDich giaoDich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giaoDich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBatDongSan = new SelectList(db.BatDongSans, "MaBatDongSan", "TieuDe", giaoDich.MaBatDongSan);
            ViewBag.MaNguoiBan = new SelectList(db.NguoiDungs, "MaNguoiDung", "Ten", giaoDich.MaNguoiBan);
            ViewBag.MaNguoiBan = new SelectList(db.MoiGiois, "MaDaiLy", "Ten", giaoDich.MaNguoiBan);
            return View(giaoDich);
        }

        // GET: GiaoDiche/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoDich giaoDich = db.GiaoDiches.Find(id);
            if (giaoDich == null)
            {
                return HttpNotFound();
            }
            return View(giaoDich);
        }

        // POST: GiaoDiche/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiaoDich giaoDich = db.GiaoDiches.Find(id);
            db.GiaoDiches.Remove(giaoDich);
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
