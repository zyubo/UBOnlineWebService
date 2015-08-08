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
    public class AnnWebController : Controller
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        //
        // GET: /AnnWeb/

        public ActionResult Index()
        {
            return View(db.Announcements.ToList());
        }

        //
        // GET: /AnnWeb/Details/5

        public ActionResult Details(string id = null)
        {
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        //
        // GET: /AnnWeb/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AnnWeb/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                db.Announcements.Add(announcement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(announcement);
        }

        //
        // GET: /AnnWeb/Edit/5

        public ActionResult Edit(string id = null)
        {
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        //
        // POST: /AnnWeb/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announcement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        //
        // GET: /AnnWeb/Delete/5

        public ActionResult Delete(string id = null)
        {
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        //
        // POST: /AnnWeb/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Announcement announcement = db.Announcements.Find(id);
            db.Announcements.Remove(announcement);
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