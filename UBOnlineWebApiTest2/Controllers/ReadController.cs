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
    public class ReadController : ApiController
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        // GET api/Read
        public IEnumerable<Read> GetReads()
        {
            return db.Reads.AsEnumerable();
        }

        // GET api/Read/5
        public Read GetRead(string id)
        {
            Read read = db.Reads.Find(id);
            if (read == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return read;
        }

        // PUT api/Read/5
        public HttpResponseMessage PutRead(string id, Read read)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != read.readId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(read).State = EntityState.Modified;

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

        // POST api/Read
        public HttpResponseMessage PostRead(Read read)
        {
            if (ModelState.IsValid)
            {
                db.Reads.Add(read);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, read);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = read.readId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Read/5
        public HttpResponseMessage DeleteRead(string id)
        {
            Read read = db.Reads.Find(id);
            if (read == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Reads.Remove(read);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, read);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}