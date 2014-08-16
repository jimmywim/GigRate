using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GigRate.Models;

namespace GigRate.Controllers
{
    public class EventInstancesController : Controller
    {
        private GigRateDataEntities db = new GigRateDataEntities();

        // GET: EventInstances
        public ActionResult Index()
        {
            var eventInstances = db.EventInstances.Include(e => e.Event);
            return View(eventInstances.ToList());
        }

        // GET: EventInstances/Event?Id=1
        public ActionResult Event(int? Id)
        {
            var eventInstances = db.EventInstances.Where(e => e.EventId == Id).Include(e => e.Event);
            return View("Index", eventInstances.ToList());
        }

        // GET: EventInstances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInstance eventInstance = db.EventInstances.Find(id);
            if (eventInstance == null)
            {
                return HttpNotFound();
            }
            return View(eventInstance);
        }

        // GET: EventInstances/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name");
            return View();
        }

        // POST: EventInstances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventId,DateFrom,DateTo")] EventInstance eventInstance)
        {
            if (ModelState.IsValid)
            {
                db.EventInstances.Add(eventInstance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventInstance.EventId);
            return View(eventInstance);
        }

        // GET: EventInstances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInstance eventInstance = db.EventInstances.Find(id);
            if (eventInstance == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventInstance.EventId);
            return View(eventInstance);
        }

        // POST: EventInstances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EventId,Name,DateFrom,DateTo")] EventInstance eventInstance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventInstance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventInstance.EventId);
            return View(eventInstance);
        }

        // GET: EventInstances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInstance eventInstance = db.EventInstances.Find(id);
            if (eventInstance == null)
            {
                return HttpNotFound();
            }
            return View(eventInstance);
        }

        // POST: EventInstances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventInstance eventInstance = db.EventInstances.Find(id);
            db.EventInstances.Remove(eventInstance);
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
