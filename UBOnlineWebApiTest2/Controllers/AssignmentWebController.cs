using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UBOnlineWebApiTest2.Models;

namespace UBOnlineWebApiTest2.Controllers
{
    public class AssignmentWebController : Controller
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        //
        // GET: /AssignmentWeb/

        public ActionResult Index()
        {
            return View(db.Assignments.ToList());
        }

        //
        // GET: /AssignmentWeb/Details/5

        public ActionResult Details(string id = null)
        {
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        //
        // GET: /AssignmentWeb/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AssignmentWeb/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Assignments.Add(assignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignment);
        }

        //
        // GET: /AssignmentWeb/Edit/5

        public ActionResult Edit(string id = null)
        {
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        //
        // POST: /AssignmentWeb/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignment);
        }

        //
        // GET: /AssignmentWeb/Delete/5

        public ActionResult Delete(string id = null)
        {
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        //
        // POST: /AssignmentWeb/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Assignment assignment = db.Assignments.Find(id);
            db.Assignments.Remove(assignment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}