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
    public class ReadWebController : Controller
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        //
        // GET: /ReadWeb/

        public ActionResult Index()
        {
            return View(db.Reads.ToList());
        }

        //
        // GET: /ReadWeb/Details/5

        public ActionResult Details(string id = null)
        {
            Read read = db.Reads.Find(id);
            if (read == null)
            {
                return HttpNotFound();
            }
            return View(read);
        }

        //
        // GET: /ReadWeb/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ReadWeb/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Read read)
        {
            if (ModelState.IsValid)
            {
                db.Reads.Add(read);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(read);
        }

        //
        // GET: /ReadWeb/Edit/5

        public ActionResult Edit(string id = null)
        {
            Read read = db.Reads.Find(id);
            if (read == null)
            {
                return HttpNotFound();
            }
            return View(read);
        }

        //
        // POST: /ReadWeb/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Read read)
        {
            if (ModelState.IsValid)
            {
                db.Entry(read).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(read);
        }

        //
        // GET: /ReadWeb/Delete/5

        public ActionResult Delete(string id = null)
        {
            Read read = db.Reads.Find(id);
            if (read == null)
            {
                return HttpNotFound();
            }
            return View(read);
        }

        //
        // POST: /ReadWeb/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Read read = db.Reads.Find(id);
            db.Reads.Remove(read);
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