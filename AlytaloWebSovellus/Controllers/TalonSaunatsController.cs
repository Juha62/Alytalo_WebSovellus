using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlytaloWebSovellus;

namespace AlytaloWebSovellus.Controllers
{
    public class TalonSaunatsController : Controller
    {
        private AlytaloEntities db = new AlytaloEntities();

        // GET: TalonSaunats
        public ActionResult Index()
        {
            return View(db.TalonSaunats.ToList());
        }

        // GET: TalonSaunats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalonSaunat talonSaunat = db.TalonSaunats.Find(id);
            if (talonSaunat == null)
            {
                return HttpNotFound();
            }
            return View(talonSaunat);
        }

        // GET: TalonSaunats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TalonSaunats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaunaId,SaunaTavoiteLampotila,SaunaNykyLampotila,SaunanTila,SaunanNimi,PaivaMaara")] TalonSaunat talonSaunat)
        {
            if (ModelState.IsValid)
            {
                db.TalonSaunats.Add(talonSaunat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talonSaunat);
        }

        // GET: TalonSaunats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalonSaunat talonSaunat = db.TalonSaunats.Find(id);
            if (talonSaunat == null)
            {
                return HttpNotFound();
            }
            return View(talonSaunat);
        }

        // POST: TalonSaunats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaunaId,SaunaTavoiteLampotila,SaunaNykyLampotila,SaunanTila,SaunanNimi,PaivaMaara")] TalonSaunat talonSaunat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talonSaunat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talonSaunat);
        }

        // GET: TalonSaunats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalonSaunat talonSaunat = db.TalonSaunats.Find(id);
            if (talonSaunat == null)
            {
                return HttpNotFound();
            }
            return View(talonSaunat);
        }

        // POST: TalonSaunats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TalonSaunat talonSaunat = db.TalonSaunats.Find(id);
            db.TalonSaunats.Remove(talonSaunat);
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
