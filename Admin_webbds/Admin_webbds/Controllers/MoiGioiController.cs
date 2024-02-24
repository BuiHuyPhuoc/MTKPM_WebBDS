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
    public class MoiGioiController : Controller
    {
        private BDS_TestEntities db = new BDS_TestEntities();

        // GET: MoiGioi
        public ActionResult Index()
        {
            return View(db.MoiGiois.ToList());
        }

        // GET: MoiGioi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoiGioi moiGioi = db.MoiGiois.Find(id);
            if (moiGioi == null)
            {
                return HttpNotFound();
            }
            return View(moiGioi);
        }

        // GET: MoiGioi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoiGioi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDaiLy,Ten,Email,DienThoai,DiaChi,Passowd")] MoiGioi moiGioi)
        {
            if (ModelState.IsValid)
            {
                db.MoiGiois.Add(moiGioi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moiGioi);
        }

        // GET: MoiGioi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoiGioi moiGioi = db.MoiGiois.Find(id);
            if (moiGioi == null)
            {
                return HttpNotFound();
            }
            return View(moiGioi);
        }

        // POST: MoiGioi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDaiLy,Ten,Email,DienThoai,DiaChi,Passowd")] MoiGioi moiGioi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moiGioi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moiGioi);
        }

        // GET: MoiGioi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoiGioi moiGioi = db.MoiGiois.Find(id);
            if (moiGioi == null)
            {
                return HttpNotFound();
            }
            return View(moiGioi);
        }

        // POST: MoiGioi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoiGioi moiGioi = db.MoiGiois.Find(id);
            db.MoiGiois.Remove(moiGioi);
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
