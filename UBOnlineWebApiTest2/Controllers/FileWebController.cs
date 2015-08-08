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
    public class FileWebController : Controller
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        //
        // GET: /FileWeb/

        public ActionResult Index()
        {
            return View(db.Files.ToList());
        }

        //
        // GET: /FileWeb/Details/5

        public ActionResult Details(string id = null)
        {
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        //
        // GET: /FileWeb/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FileWeb/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(File file)
        {
            if (ModelState.IsValid)
            {
                db.Files.Add(file);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(file);
        }

        //
        // GET: /FileWeb/Edit/5

        public ActionResult Edit(string id = null)
        {
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        //
        // POST: /FileWeb/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(File file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(file).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(file);
        }

        //
        // GET: /FileWeb/Delete/5

        public ActionResult Delete(string id = null)
        {
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        //
        // POST: /FileWeb/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            File file = db.Files.Find(id);
            db.Files.Remove(file);
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