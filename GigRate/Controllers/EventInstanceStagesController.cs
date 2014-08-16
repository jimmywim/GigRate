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
    public class EventInstanceStagesController : Controller
    {
        private GigRateDataEntities db = new GigRateDataEntities();

        // GET: EventInstanceStages
        public ActionResult Index()
        {
            var eventInstanceStages = db.EventInstanceStages.Include(e => e.EventInstance).Include(e => e.Stage);
            return View(eventInstanceStages.ToList());
        }

        // GET: EventInstanceStages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInstanceStage eventInstanceStage = db.EventInstanceStages.Find(id);
            if (eventInstanceStage == null)
            {
                return HttpNotFound();
            }
            return View(eventInstanceStage);
        }

        // GET: EventInstanceStages/Create
        public ActionResult Create()
        {
            ViewBag.EventInstanceId = new SelectList(db.EventInstances, "Id", "Name");
            ViewBag.StageId = new SelectList(db.Stages, "Id", "Name");
            return View();
        }

        // POST: EventInstanceStages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StageId,EventInstanceId")] EventInstanceStage eventInstanceStage)
        {
            if (ModelState.IsValid)
            {
                db.EventInstanceStages.Add(eventInstanceStage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventInstanceStage.EventInstanceId);
            ViewBag.StageId = new SelectList(db.Stages, "Id", "Name", eventInstanceStage.StageId);
            return View(eventInstanceStage);
        }

        // GET: EventInstanceStages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInstanceStage eventInstanceStage = db.EventInstanceStages.Find(id);
            if (eventInstanceStage == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventInstanceStage.EventInstanceId);
            ViewBag.StageId = new SelectList(db.Stages, "Id", "Name", eventInstanceStage.StageId);
            return View(eventInstanceStage);
        }

        // POST: EventInstanceStages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StageId,EventInstanceId")] EventInstanceStage eventInstanceStage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventInstanceStage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventInstanceStage.EventInstanceId);
            ViewBag.StageId = new SelectList(db.Stages, "Id", "Name", eventInstanceStage.StageId);
            return View(eventInstanceStage);
        }

        // GET: EventInstanceStages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInstanceStage eventInstanceStage = db.EventInstanceStages.Find(id);
            if (eventInstanceStage == null)
            {
                return HttpNotFound();
            }
            return View(eventInstanceStage);
        }

        // POST: EventInstanceStages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventInstanceStage eventInstanceStage = db.EventInstanceStages.Find(id);
            db.EventInstanceStages.Remove(eventInstanceStage);
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
