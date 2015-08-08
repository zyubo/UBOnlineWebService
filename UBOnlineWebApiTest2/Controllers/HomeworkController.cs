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
    public class HomeworkController : ApiController
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        // GET api/Homework
        public IEnumerable<Assignment> GetAssignments()
        {
            return db.Assignments.AsEnumerable();
        }

        //// GET api/Homework/5
        //public AsmSingleJson GetAssignment(string id)
        //{
        //    String userNameIn = id.Split('@')[0];
        //    String passwordIn = id.Split('@')[1];
        //    String courseIdIn = id.Split('@')[2];
        //    AsmSingleJson asmSingleJson = new AsmSingleJson();
        //    if (AuthController.isValidUser(userNameIn, passwordIn))
        //    {
        //        IQueryable<Assignment> AsmOut =
        //            from s in db.Assignments
        //            where s.stuName == userNameIn && s.courseId == courseIdIn
        //            orderby s.asmId
        //            select s;
        //        foreach(Assignment a in AsmOut)
        //        {
        //            File file = db.Files.Find(a.fileId);
        //            AsmSingleJsonElement asmSingleJsonElement = new AsmSingleJsonElement();
        //            asmSingleJsonElement.hwName = file.fileId;
        //            asmSingleJsonElement.link = file.fileLink;
        //            asmSingleJsonElement.submitted = a.submitted;
        //            asmSingleJson.asmSingleList.Add(asmSingleJsonElement);
        //        }
        //    }
        //    return asmSingleJson;
        //}

        // GET api/Homework/5
        public List<AsmSingleJsonElement> GetAssignment(string id)
        //public AsmSingleJson GetAssignment(string id)
        {
            String userNameIn = id.Split('@')[0];
            String passwordIn = id.Split('@')[1];
            String courseIdIn = id.Split('@')[2];
            AsmSingleJson asmSingleJson = new AsmSingleJson();
            List<Assignment> asmList = new List<Assignment>();
            List<AsmSingleJsonElement> asmMutiList = new List<AsmSingleJsonElement>();
            List<Register> gradeList = new List<Register>();
            List<File> fileList = new List<File>();
            if (AuthController.isValidUser(userNameIn, passwordIn))
            {
                IQueryable<Assignment> asmOut =
                    from s in db.Assignments
                    where s.stuName == userNameIn && s.courseId == courseIdIn
                    orderby s.asmId
                    select s;
                asmList = asmOut.ToList<Assignment>();
                IQueryable<File> fileOut =
                    from f in db.Files
                    orderby f.fileId
                    select f;
                fileList = fileOut.ToList<File>();
                IQueryable<Register> gradeOut =
                    from r in db.Registers
                    where r.stuName == userNameIn && r.courseId == courseIdIn
                    orderby r.regId
                    select r;
                gradeList = gradeOut.ToList<Register>(); //asmSingleJson
                foreach (Register r in gradeList)
                {
                    asmSingleJson.totalGrade = r.finalGrade;
                }
                foreach (Assignment a in asmList)
                {
                    foreach (File f in fileList)
                    {
                        if (a.fileId == f.fileId)
                        {
                            AsmSingleJsonElement asmSingleJsonElement = new AsmSingleJsonElement();
                            asmSingleJsonElement.hwName = f.fileId;
                            asmSingleJsonElement.link = f.fileLink;
                            asmSingleJsonElement.submitted = a.submitted;
                            asmSingleJson.asmSingleList.Add(asmSingleJsonElement);
                            asmMutiList.Add(asmSingleJsonElement);
                        }
                    }
                }
            }
            return asmMutiList;
            //return asmSingleJson;
        }

        // PUT api/Homework/5
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

        // POST api/Homework
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

        // DELETE api/Homework/5
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