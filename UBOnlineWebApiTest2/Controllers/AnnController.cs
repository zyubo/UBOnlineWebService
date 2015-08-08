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
    public class AnnController : ApiController
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        // GET api/Ann
        public IEnumerable<Announcement> GetAnnouncements()
        {
            return db.Announcements.AsEnumerable();
        }

        // GET api/Ann/5
        public List<Announcement> GetAnnouncement(string id)
        {
            String userNameIn = id.Split('@')[0];
            String passwordIn = id.Split('@')[1];
            String courseIdIn = id.Split('@')[2];
            AnnSingleJson annSingleJson = new AnnSingleJson();
            List<Announcement> annList = new List<Announcement>();
            if (AuthController.isValidUser(userNameIn, passwordIn))
            {
                IQueryable<Announcement> annOut =
                    from s in db.Announcements
                    where courseIdIn == s.courseId
                    orderby s.annId
                    select s;
                annSingleJson.annSingleList = annOut.ToList<Announcement>();
                annList = annOut.ToList<Announcement>();
            }
            return annList;
        }

        // PUT api/Ann/5
        public HttpResponseMessage PutAnnouncement(string id, Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != announcement.annId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(announcement).State = EntityState.Modified;

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

        // POST api/Ann
        public HttpResponseMessage PostAnnouncement(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                db.Announcements.Add(announcement);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, announcement);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = announcement.annId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Ann/5
        public HttpResponseMessage DeleteAnnouncement(string id)
        {
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Announcements.Remove(announcement);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, announcement);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}