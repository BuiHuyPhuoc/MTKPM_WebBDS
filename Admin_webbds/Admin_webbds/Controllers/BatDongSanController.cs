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
    public class BatDongSanController : Controller
    {
        private BDS_TestEntities db = new BDS_TestEntities();

        // GET: BatDongSan
        public ActionResult Index()
        {
            var batDongSans = db.BatDongSans.Include(b => b.MoiGioi);
            return View(batDongSans.ToList());
        }


        [HttpPost]
        public ActionResult Index(decimal? minPrice, decimal? maxPrice, string keyword)
        {
            var query = db.BatDongSans.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                if (int.TryParse(keyword, out int numericKeyword))
                {
                    query = query.Where(bds => bds.MaBatDongSan == numericKeyword);
                }
                else
                {
                    query = query.Where(bds => bds.TieuDe.Contains(keyword));
                }
            }

            if (minPrice.HasValue)
            {
                query = query.Where(bds => bds.Gia >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(bds => bds.Gia <= maxPrice.Value);
            }

            var batDongSans = query.ToList();

            return View("Index", batDongSans); // Đảm bảo rằng bạn sử dụng chính xác tên view
        }
        public ActionResult TrangThaiMoiGioi()
        {
            var batDongSans = db.BatDongSans.ToList();
            var batDongSanVMs = new List<BatDongSanVM>();

            foreach (var b in batDongSans)
            {
                var batDongSanVM = new BatDongSanVM()
                {
                    MaBatDongSan = b.MaBatDongSan,
                    TieuDe = b.TieuDe,
                    TrangThai = b.TrangThai
                };

                batDongSanVMs.Add(batDongSanVM);
            }

            return View(batDongSanVMs);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int id, bool newStatus)
        {
            var project = db.BatDongSans.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }

            project.TrangThai = newStatus;
            db.SaveChanges();

            return Json(new { success = true, message = "Cập nhật trạng thái thành công" });
        }


        // GET: BatDongSan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatDongSan batDongSan = db.BatDongSans.Find(id);
            if (batDongSan == null)
            {
                return HttpNotFound();
            }
            return View(batDongSan);
        }

        // GET: BatDongSan/Create
        public ActionResult Create()
        {
            ViewBag.MaDaiLy = new SelectList(db.MoiGiois, "MaDaiLy", "Ten");
            return View();
        }

        // POST: BatDongSan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBatDongSan,TieuDe,MoTa,Gia,DienTich,ViTri,Anh,TienNghi,ThongTinLienHe,NgayTao,NgaySua,MaDaiLy,TrangThai,PhapLy,urlmap")] BatDongSan batDongSan)
        {
            if (ModelState.IsValid)
            {
                db.BatDongSans.Add(batDongSan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDaiLy = new SelectList(db.MoiGiois, "MaDaiLy", "Ten", batDongSan.MaDaiLy);
            return View(batDongSan);
        }

        // GET: BatDongSan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatDongSan batDongSan = db.BatDongSans.Find(id);
            if (batDongSan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDaiLy = new SelectList(db.MoiGiois, "MaDaiLy", "Ten", batDongSan.MaDaiLy);
            return View(batDongSan);
        }

        // POST: BatDongSan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBatDongSan,TieuDe,MoTa,Gia,DienTich,ViTri,Anh,TienNghi,ThongTinLienHe,NgayTao,NgaySua,MaDaiLy,TrangThai,PhapLy,urlmap")] BatDongSan batDongSan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batDongSan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDaiLy = new SelectList(db.MoiGiois, "MaDaiLy", "Ten", batDongSan.MaDaiLy);
            return View(batDongSan);
        }

        // GET: BatDongSan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatDongSan batDongSan = db.BatDongSans.Find(id);
            if (batDongSan == null)
            {
                return HttpNotFound();
            }
            return View(batDongSan);
        }

        // POST: BatDongSan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BatDongSan batDongSan = db.BatDongSans.Find(id);
            db.BatDongSans.Remove(batDongSan);
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
