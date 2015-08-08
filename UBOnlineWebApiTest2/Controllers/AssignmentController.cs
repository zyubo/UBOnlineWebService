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
    public class AssignmentController : ApiController
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        // GET api/Assignment
        public IEnumerable<Assignment> GetAssignments()
        {
            return db.Assignments.AsEnumerable();
        }

        //// GET api/Assignment/5
        //public AssignmentJson GetAssignment(string id)
        //{
        //    String userNameIn = id.Split('@')[0];
        //    String passwordIn = id.Split('@')[1];
        //    AssignmentJson asmJson = new AssignmentJson();
        //    if (AuthController.isValidUser(userNameIn, passwordIn))
        //    {
        //        IQueryable<Register> RegOut =
        //            from s in db.Registers
        //            where s.stuName == userNameIn
        //            orderby s.regId
        //            select s;
        //        foreach (Register r in RegOut)
        //        {
        //            //Course announcement = db.Announcements.Find(r.annId);
        //            Course course = db.Courses.Find(r.courseId);
        //            if (course == null)
        //            {
        //                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //            }
        //            AsmMutiJson asmMutiJson = new AsmMutiJson();
        //            asmMutiJson.courseName = course.courseName;
        //            asmJson.asmList.Add(asmMutiJson);
        //        }
        //    }
        //    return asmJson;
        //}

        // GET api/Assignment/5
        public List<AsmMutiJson> GetAssignment(string id)
        {
            String userNameIn = id.Split('@')[0];
            String passwordIn = id.Split('@')[1];
            AssignmentJson asmJson = new AssignmentJson();
            List<Register> gradeList = new List<Register>();
            List<Course> courseList = new List<Course>();
            List<AsmMutiJson> asmMutiList = new List<AsmMutiJson>();
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
                            AsmMutiJson asmMutiJson = new AsmMutiJson();
                            asmMutiJson.courseName = c.courseName;
                            asmMutiJson.courseId = c.courseId;
                            asmJson.asmList.Add(asmMutiJson);
                            asmMutiList.Add(asmMutiJson);
                        }
                    }
                }
            }
            return asmMutiList;
        }

        // PUT api/Assignment/5
        public HttpResponseMessage PutAssignment(string id, Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != assignment.asmId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(assignment).State = EntityState.Modified;

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

        // POST api/Assignment
        public HttpResponseMessage PostAssignment(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Assignments.Add(assignment);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, assignment);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = assignment.asmId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Assignment/5
        public HttpResponseMessage DeleteAssignment(string id)
        {
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Assignments.Remove(assignment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, assignment);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}