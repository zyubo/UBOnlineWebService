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
    public class ProfessorWebController : Controller
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        //
        // GET: /ProfessorWeb/

        public ActionResult Index()
        {
            return View(db.Professors.ToList());
        }

        //
        // GET: /ProfessorWeb/Details/5

        public ActionResult Details(string id = null)
        {
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        //
        // GET: /ProfessorWeb/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ProfessorWeb/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Professors.Add(professor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(professor);
        }

        //
        // GET: /ProfessorWeb/Edit/5

        public ActionResult Edit(string id = null)
        {
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        //
        // POST: /ProfessorWeb/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professor);
        }

        //
        // GET: /ProfessorWeb/Delete/5

        public ActionResult Delete(string id = null)
        {
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        //
        // POST: /ProfessorWeb/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Professor professor = db.Professors.Find(id);
            db.Professors.Remove(professor);
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