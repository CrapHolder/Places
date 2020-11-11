using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using blessrng.Models;

namespace blessrng.Controllers
{
    public class ReqestsController : Controller
    {
        private ReqestsEntities db = new ReqestsEntities();

        // GET: Reqests
        public ActionResult Index()
        {
            var reqest = db.Reqest.Include(r => r.Status);
            return View(reqest.ToList());
        }

        // GET: Reqests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reqest reqest = db.Reqest.Find(id);
            if (reqest == null)
            {
                return HttpNotFound();
            }
            return View(reqest);
        }

        // GET: Reqests/Create
        public ActionResult Create()
        {
            ViewBag.StatusID = new SelectList(db.Status, "ID", "StatusName");
            return View();
        }

        // POST: Reqests/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,First,Second,Third,Phone,Out,In,Date_Out,StatusID")] Reqest reqest)
        {
            if (ModelState.IsValid)
            {
                db.Reqest.Add(reqest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StatusID = new SelectList(db.Status, "ID", "StatusName", reqest.StatusID);
            return View(reqest);
        }

        // GET: Reqests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reqest reqest = db.Reqest.Find(id);
            if (reqest == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusID = new SelectList(db.Status, "ID", "StatusName", reqest.StatusID);
            return View(reqest);
        }

        // POST: Reqests/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,First,Second,Third,Phone,Out,In,Date_Out,StatusID")] Reqest reqest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reqest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusID = new SelectList(db.Status, "ID", "StatusName", reqest.StatusID);
            return View(reqest);
        }

        // GET: Reqests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reqest reqest = db.Reqest.Find(id);
            if (reqest == null)
            {
                return HttpNotFound();
            }
            return View(reqest);
        }

        // POST: Reqests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reqest reqest = db.Reqest.Find(id);
            db.Reqest.Remove(reqest);
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
