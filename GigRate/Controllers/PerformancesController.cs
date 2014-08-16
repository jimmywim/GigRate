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
    public class PerformancesController : Controller
    {
        private GigRateDataEntities db = new GigRateDataEntities();

        // GET: Performances
        public ActionResult Index()
        {
            var performances = db.Performances.Include(p => p.Act).Include(p => p.EventInstanceStage);
            return View(performances.ToList());
        }

        // GET: Performances/AtEvent?Id=1
        public ActionResult AtEvent(int? Id)
        {
            var performances = db.Performances.Where(p => Id == p.EventInstanceStage.EventInstance.EventId).Include(p => p.Act).Include(p => p.EventInstanceStage);
            return View("Index", performances.ToList());
        }

        // GET: Performances/AtEventInstance?Id=1
        public ActionResult AtEventInstance(int? Id)
        {
            var performances = db.Performances.Where(p => Id == p.EventInstanceStage.EventInstanceId).Include(p => p.Act).Include(p => p.EventInstanceStage);
            return View("Index", performances.ToList());
        }
        
        // GET: Performances/OnStage?Id=1
        public ActionResult OnStage(int? Id)
        {
            var performances = db.Performances.Where(p => Id == p.EventInstanceStage.StageId).Include(p => p.Act).Include(p => p.EventInstanceStage);
            return View("Index", performances.ToList());
        }

        // GET: Performances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                return HttpNotFound();
            }
            return View(performance);
        }

        // GET: Performances/Create
        public ActionResult Create()
        {
            ViewBag.ActId = new SelectList(db.Acts, "Id", "Name");
            ViewBag.EventInstanceStageId = new SelectList(db.EventInstanceStages, "Id", "FriendlyName");
            return View();
        }

        // POST: Performances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TimeOn,TimeOff,ActId,EventInstanceStageId")] Performance performance)
        {
            if (ModelState.IsValid)
            {
                db.Performances.Add(performance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActId = new SelectList(db.Acts, "Id", "Name", performance.ActId);
            ViewBag.EventInstanceStageId = new SelectList(db.EventInstanceStages, "Id", "Id", performance.EventInstanceStageId);
            return View(performance);
        }

        // GET: Performances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActId = new SelectList(db.Acts, "Id", "Name", performance.ActId);
            ViewBag.EventInstanceStageId = new SelectList(db.EventInstanceStages, "Id", "FriendlyName", performance.EventInstanceStageId);
            return View(performance);
        }

        // POST: Performances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TimeOn,TimeOff,ActId,EventInstanceStageId")] Performance performance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(performance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActId = new SelectList(db.Acts, "Id", "Name", performance.ActId);
            ViewBag.EventInstanceStageId = new SelectList(db.EventInstanceStages, "Id", "Id", performance.EventInstanceStageId);
            return View(performance);
        }

        // GET: Performances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                return HttpNotFound();
            }
            return View(performance);
        }

        // POST: Performances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Performance performance = db.Performances.Find(id);
            db.Performances.Remove(performance);
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
