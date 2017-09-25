﻿using System;
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
    public class TalonLammotsController : Controller
    {
        private JuhaDBEntities1 db = new JuhaDBEntities1();

        // GET: TalonLammots
        public ActionResult Index()
        {
            return View(db.TalonLammot.ToList());
        }

        // GET: TalonLammots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalonLammot talonLammot = db.TalonLammot.Find(id);
            if (talonLammot == null)
            {
                return HttpNotFound();
            }
            return View(talonLammot);
        }

        // GET: TalonLammots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TalonLammots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HuoneId,Huone,TavoiteLampoTila,TalonNykyLampoTila,PaivaMaara")] TalonLammot talonLammot)
        {
            if (ModelState.IsValid)
            {
                db.TalonLammot.Add(talonLammot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talonLammot);
        }

        // GET: TalonLammots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalonLammot talonLammot = db.TalonLammot.Find(id);
            if (talonLammot == null)
            {
                return HttpNotFound();
            }
            return View(talonLammot);
        }

        // POST: TalonLammots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HuoneId,Huone,TavoiteLampoTila,TalonNykyLampoTila,PaivaMaara")] TalonLammot talonLammot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talonLammot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talonLammot);
        }

        // GET: TalonLammots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalonLammot talonLammot = db.TalonLammot.Find(id);
            if (talonLammot == null)
            {
                return HttpNotFound();
            }
            return View(talonLammot);
        }

        // POST: TalonLammots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TalonLammot talonLammot = db.TalonLammot.Find(id);
            db.TalonLammot.Remove(talonLammot);
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
