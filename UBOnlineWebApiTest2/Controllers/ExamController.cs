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
    public class ExamController : Controller
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();
        public UBOnlineExam exam = new UBOnlineExam();
        public static string currentQuestionTitle = "";
        public static string currentQuestionContent = "";
        public static int currentQuestionId = 0;
        private string[] questionTitle = {"Question 1","Question 2","Question 3"};
        private string[] questionContent = { 
                                              "A car averages 27 miles per gallon. If gas costs $4.04 per gallon, which of the following is closest to how much the gas would cost for this car to travel 2,727 typical miles? (A.543 B.147.5 C.23.5 D.44)",
                                              "Sales for a business were 3 million dollars more the second year than the first, and sales for the third year were double the sales for the second year. If sales for the third year were 38 million dollars, what were sales, in millions of dollars, for the first year? (A.16 B.17.5 C.20.5 D.22)", 
                                              "The length, in inches, of a box is 3 inches less than twice its width, in inches. Which of the following gives the length, l inches, in terms of the width, w inches, of the box? (A.76 B.173 C.23 D.78)" };
        //
        // GET: /Exam/

        public ActionResult Index()
        {
            return View(db.UBOnlineExam.ToList());
        }

        //
        // GET: /Exam/Details/5

        public ActionResult Details(string id = null)
        {
            UBOnlineExam ubonlineexam = db.UBOnlineExam.Find(id);
            if (ubonlineexam == null)
            {
                return HttpNotFound();
            }
            return View(ubonlineexam);
        }

        //
        // GET: /Exam/Create

        public ActionResult Create(string id)
        {
            currentQuestionId = int.Parse(id);
            currentQuestionTitle = questionTitle[currentQuestionId - 1];
            currentQuestionContent = questionContent[currentQuestionId - 1];
            exam.questionTitle = currentQuestionTitle;
            exam.questionContent = currentQuestionContent;
            return View(exam);
            //return View(db.UBOnlineExam.ToList());
        }

        //
        // POST: /Exam/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UBOnlineExam ubonlineexam)
        {
            ubonlineexam.titleId = "title_" + GenerateID();
            //if (ModelState.IsValid)
            if (ubonlineexam != null)
            {
                db.UBOnlineExam.Add(ubonlineexam);
                db.SaveChanges();
                currentQuestionId++;
                if (currentQuestionId > 3)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Create", new { id = currentQuestionId });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            Console.WriteLine(errors.ToString());

            return View(ubonlineexam);
        }

        public string GenerateID()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        //
        // GET: /Exam/Edit/5

        public ActionResult Edit(string id = null)
        {
            UBOnlineExam ubonlineexam = db.UBOnlineExam.Find(id);
            if (ubonlineexam == null)
            {
                return HttpNotFound();
            }
            return View(ubonlineexam);
        }

        //
        // POST: /Exam/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UBOnlineExam ubonlineexam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ubonlineexam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ubonlineexam);
        }

        //
        // GET: /Exam/Delete/5

        public ActionResult Delete(string id = null)
        {
            UBOnlineExam ubonlineexam = db.UBOnlineExam.Find(id);
            if (ubonlineexam == null)
            {
                return HttpNotFound();
            }
            return View(ubonlineexam);
        }

        //
        // POST: /Exam/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UBOnlineExam ubonlineexam = db.UBOnlineExam.Find(id);
            db.UBOnlineExam.Remove(ubonlineexam);
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