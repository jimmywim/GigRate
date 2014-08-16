using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GigRate.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework; 

namespace GigRate.Controllers
{
    public class PerformanceRatingsController : Controller
    {
        private GigRateDataEntities db = new GigRateDataEntities();

        /// <summary>
        /// Application DB context
        /// </summary>
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        /// <summary>
        /// User manager - attached to application DB context
        /// </summary>
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public PerformanceRatingsController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: PerformanceRatings
        public ActionResult Index()
        {
            var performanceRatings = db.PerformanceRatings.Include(p => p.Performance);
            return View(performanceRatings.ToList());
        }

        // GET: PerformanceRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerformanceRating performanceRating = db.PerformanceRatings.Find(id);
            if (performanceRating == null)
            {
                return HttpNotFound();
            }
            return View(performanceRating);
        }

        // GET: PerformanceRatings/Create
        public ActionResult Create()
        {
            ViewBag.PerformanceId = new SelectList(db.Performances, "Id", "Id");
            return View();
        }

        public ActionResult RatePerformance(int? performanceId)
        {
            ViewBag.PerformanceId = performanceId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RatePerformance([Bind(Include = "Rating,Comments,IsPublic,PerformanceId")] PerformanceRating performanceRating)
        {
            if (ModelState.IsValid)
            {
                performanceRating.UserId = User.Identity.GetUserId();
                performanceRating.Performance = db.Performances.Where(p => p.Id == performanceRating.PerformanceId).FirstOrDefault();
                db.PerformanceRatings.Add(performanceRating);
                db.SaveChanges();
                return RedirectToAction("Index", "Performances");
            }

            return View(performanceRating);
        }

        // POST: PerformanceRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Rating,Comments,IsPublic,PerformanceId")] PerformanceRating performanceRating)
        {
            if (ModelState.IsValid)
            {
                db.PerformanceRatings.Add(performanceRating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PerformanceId = new SelectList(db.Performances, "Id", "Id", performanceRating.PerformanceId);
            return View(performanceRating);
        }

        // GET: PerformanceRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerformanceRating performanceRating = db.PerformanceRatings.Find(id);
            if (performanceRating == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerformanceId = new SelectList(db.Performances, "Id", "Id", performanceRating.PerformanceId);
            return View(performanceRating);
        }

        // POST: PerformanceRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Rating,Comments,IsPublic,PerformanceId")] PerformanceRating performanceRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(performanceRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PerformanceId = new SelectList(db.Performances, "Id", "Id", performanceRating.PerformanceId);
            return View(performanceRating);
        }

        // GET: PerformanceRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerformanceRating performanceRating = db.PerformanceRatings.Find(id);
            if (performanceRating == null)
            {
                return HttpNotFound();
            }
            return View(performanceRating);
        }

        // POST: PerformanceRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PerformanceRating performanceRating = db.PerformanceRatings.Find(id);
            db.PerformanceRatings.Remove(performanceRating);
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
