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
    public class RegisterWebController : Controller
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        //
        // GET: /RegisterWeb/

        public ActionResult Index()
        {
            return View(db.Registers.ToList());
        }

        //
        // GET: /RegisterWeb/Details/5

        public ActionResult Details(string id = null)
        {
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        //
        // GET: /RegisterWeb/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RegisterWeb/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Register register)
        {
            if (ModelState.IsValid)
            {
                db.Registers.Add(register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(register);
        }

        //
        // GET: /RegisterWeb/Edit/5

        public ActionResult Edit(string id = null)
        {
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        //
        // POST: /RegisterWeb/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Register register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(register);
        }

        //
        // GET: /RegisterWeb/Delete/5

        public ActionResult Delete(string id = null)
        {
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        //
        // POST: /RegisterWeb/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Register register = db.Registers.Find(id);
            db.Registers.Remove(register);
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