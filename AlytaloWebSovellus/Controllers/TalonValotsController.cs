using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlytaloWebSovellus.Models;

namespace AlytaloWebSovellus.Controllers
{
    public class TalonValotsController : Controller
    {
        private JuhaDBEntities1 db = new JuhaDBEntities1();

        // GET: TalonValots
        public ActionResult Index()
        {
            return View(db.TalonValot.ToList());
        }

        // GET: TalonValots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalonValot talonValot = db.TalonValot.Find(id);
            if (talonValot == null)
            {
                return HttpNotFound();
            }
            return View(talonValot);
        }

        // GET: TalonValots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TalonValots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Huone,ValaisinTyyppi,ValonTilaId,ValonMaara,PaivaMaara,LampunId")] TalonValot talonValot)
        {
            if (ModelState.IsValid)
            {
                db.TalonValot.Add(talonValot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talonValot);
        }

        // GET: TalonValots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalonValot talonValot = db.TalonValot.Find(id);
            if (talonValot == null)
            {
                return HttpNotFound();
            }
            return View(talonValot);
        }

        // POST: TalonValots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Huone,ValaisinTyyppi,ValonTilaId,ValonMaara,PaivaMaara,LampunId")] TalonValot talonValot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talonValot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talonValot);
        }

        // GET: TalonValots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalonValot talonValot = db.TalonValot.Find(id);
            if (talonValot == null)
            {
                return HttpNotFound();
            }
            return View(talonValot);
        }

        // POST: TalonValots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TalonValot talonValot = db.TalonValot.Find(id);
            db.TalonValot.Remove(talonValot);
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
