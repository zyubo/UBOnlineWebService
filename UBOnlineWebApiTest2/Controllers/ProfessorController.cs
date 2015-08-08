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
    public class ProfessorController : ApiController
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        // GET api/Professor
        public IEnumerable<Professor> GetProfessors()
        {
            return db.Professors.AsEnumerable();
        }

        // GET api/Professor/5
        public Professor GetProfessor(string id)
        {
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return professor;
        }

        // PUT api/Professor/5
        public HttpResponseMessage PutProfessor(string id, Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != professor.proName)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(professor).State = EntityState.Modified;

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

        // POST api/Professor
        public HttpResponseMessage PostProfessor(Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Professors.Add(professor);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, professor);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = professor.proName }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Professor/5
        public HttpResponseMessage DeleteProfessor(string id)
        {
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Professors.Remove(professor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, professor);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}