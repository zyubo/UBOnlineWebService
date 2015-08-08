using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using UBOnlineWebApiTest2.Models;

namespace UBOnlineWebApiTest2.Controllers
{
    public class GradeController : ApiController
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        // GET api/Grade
        public IEnumerable<Register> GetRegisters()
        {
            return db.Registers.AsEnumerable();
        }

        //// GET api/Grade/5
        //public GradeJson GetRegister(string id)
        //{
        //    String userNameIn = id.Split('@')[0];
        //    String passwordIn = id.Split('@')[1];
        //    GradeJson gradeJson = new GradeJson();
        //    if (AuthController.isValidUser(userNameIn, passwordIn))
        //    {
        //        IQueryable<Register> gradeOut =
        //            from s in db.Registers
        //            where s.stuName == userNameIn
        //            orderby s.regId
        //            select s;
        //        foreach (Register r in gradeOut)
        //        {
        //            //Announcement announcement = db.Announcements.Find(r.annId);
        //            Course course = db.Courses.Find(r.courseId);
        //            if (course == null)
        //            {
        //                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //            }
        //            GradeMutiJson gradeMutiJson = new GradeMutiJson();
        //            gradeMutiJson.courseName = course.courseName;
        //            gradeMutiJson.taken = r.taken;
        //            gradeMutiJson.totalGrade = r.finalGrade;
        //            gradeJson.gradeList.Add(gradeMutiJson);
        //        }
        //    }
        //    return gradeJson;
        //}

        // GET api/Grade/5
        public List<GradeMutiJson> GetRegister(string id)
        //public GradeJson GetRegister(string id)
        {
            String userNameIn = id.Split('@')[0];
            String passwordIn = id.Split('@')[1];
            GradeJson gradeJson = new GradeJson();
            List<Register> gradeList = new List<Register>();
            List<Course> courseList = new List<Course>();
            List<GradeMutiJson> gradeMutiList = new List<GradeMutiJson>();
            if (AuthController.isValidUser(userNameIn, passwordIn))
            {
                IQueryable<Register> gradeOut =
                    from r in db.Registers
                    where r.stuName == userNameIn
                    orderby r.regId
                    select r;
                gradeList = gradeOut.ToList<Register>();
                IQueryable<Course> courseOut =
                    from c in db.Courses
                    orderby c.courseId
                    select c;
                courseList = courseOut.ToList<Course>();
                foreach (Register r in gradeList)
                {
                    foreach (Course c in courseList)
                    {
                        if (r.courseId == c.courseId)
                        {
                            GradeMutiJson gradeMutiJson = new GradeMutiJson();
                            gradeMutiJson.courseName = c.courseName;
                            gradeMutiJson.courseId = c.courseId;
                            gradeMutiJson.taken = r.taken;
                            gradeMutiJson.totalGrade = r.finalGrade;
                            gradeJson.gradeList.Add(gradeMutiJson);
                            gradeMutiList.Add(gradeMutiJson);
                        }
                    }
                }
            }
            return gradeMutiList;
            //return gradeJson;
        }

        // PUT api/Grade/5
        public HttpResponseMessage PutRegister(string id, Register register)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != register.regId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(register).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Grade
        public HttpResponseMessage PostRegister(Register register)
        {
            if (ModelState.IsValid)
            {
                db.Registers.Add(register);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, register);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = register.regId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Grade/5
        public HttpResponseMessage DeleteRegister(string id)
        {
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Registers.Remove(register);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, register);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}