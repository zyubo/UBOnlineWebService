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
    public class ScoreController : ApiController
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        // GET api/Score
        public IEnumerable<Assignment> GetAssignments()
        {
            return db.Assignments.AsEnumerable();
        }

        // GET api/Score/5
        //public List<Assignment> GetAssignment(string id)
        public List<GradeSingleJson> GetAssignment(string id)
        {
            String userNameIn = id.Split('@')[0];
            String passwordIn = id.Split('@')[1];
            String courseIdIn = id.Split('@')[2];
            GradeSingleJson gradeSingleJson = new GradeSingleJson();
            List<GradeSingleJson> gradeSingleJsonList = new List<GradeSingleJson>();
            List<Assignment> asmMutiList = new List<Assignment>();
            if (AuthController.isValidUser(userNameIn, passwordIn))
            {
                IQueryable<Register> scoreOut =
                    from s in db.Registers
                    where s.stuName == userNameIn && courseIdIn == s.courseId
                    orderby s.regId
                    select s;
                IQueryable<Assignment> AsmOut =
                    from s in db.Assignments
                    where s.stuName == userNameIn && courseIdIn == s.courseId
                    orderby s.asmId
                    select s;
                foreach (Register r in scoreOut)
                    gradeSingleJson.totalGrade = r.finalGrade;
                gradeSingleJson.grade = AsmOut.ToList<Assignment>();
                gradeSingleJsonList.Add(gradeSingleJson);
                asmMutiList = AsmOut.ToList<Assignment>();
            }
            //return asmMutiList;
            //return gradeSingleJson;
            return gradeSingleJsonList;
        }

        // PUT api/Score/5
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

        // POST api/Score
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

        // DELETE api/Score/5
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