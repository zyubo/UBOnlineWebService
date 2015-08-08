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
    public class WelcomeController : ApiController
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        // GET api/Welcome
        public IEnumerable<Announcement> GetAnnouncements()
        {
            return db.Announcements.AsEnumerable();
        }

        //// GET api/Welcome/5
        //public WelcomeJson GetAnnouncement(string id) //user1
        //{
        //    String userNameIn = id.Split('@')[0];
        //    String passwordIn = id.Split('@')[1];
        //    WelcomeJson welcomeJson = new WelcomeJson();
        //    if (AuthController.isValidUser(userNameIn, passwordIn))
        //    {
        //        IQueryable<Read> ReadOut =
        //            from s in db.Reads
        //            where s.read == "false" && s.stuName == userNameIn
        //            orderby s.readId
        //            select s;
        //        foreach (Read r in ReadOut)
        //        {
        //            Announcement announcement = db.Announcements.Find(r.annId);
        //            Course course = db.Courses.Find(announcement.courseId);
        //            if (announcement == null)
        //            {
        //                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //            }
        //            AnnMutiJson annMutiJson = new AnnMutiJson();
        //            annMutiJson.type = announcement.annType;
        //            annMutiJson.courseName = course.courseName;
        //            annMutiJson.content = announcement.content;
        //            welcomeJson.annList.Add(annMutiJson);
        //        }
        //    }
        //    return welcomeJson;
        //}

        // GET api/Welcome/5
        //public WelcomeJson GetAnnouncement(string id) //user1
        public List<AnnMutiJson> GetAnnouncement(string id) //user1
        {
            String userNameIn = id.Split('@')[0];
            String passwordIn = id.Split('@')[1];
            WelcomeJson welcomeJson = new WelcomeJson();
            List<Read> readList = new List<Read>();
            List<Announcement> annList = new List<Announcement>();
            List<Course> courseList = new List<Course>();
            List<AnnMutiJson> annMutiList = new List<AnnMutiJson>();
            if (AuthController.isValidUser(userNameIn, passwordIn))
            {
                IQueryable<Read> ReadOut =
                    from s in db.Reads
                    where s.read == "false" && s.stuName == userNameIn
                    orderby s.readId
                    select s;
                readList = ReadOut.ToList<Read>();
                IQueryable<Announcement> AnnOut =
                    from s in db.Announcements
                    orderby s.annId
                    select s;
                annList = AnnOut.ToList<Announcement>();
                IQueryable<Course> courseOut =
                    from s in db.Courses
                    orderby s.courseId
                    select s;
                courseList = courseOut.ToList<Course>();
                foreach (Read r in readList)
                {
                    foreach (Announcement a in annList)
                    {
                        if (a.annId == r.annId)
                        {
                            foreach (Course c in courseList)
                            {
                                if (c.courseId == a.courseId)
                                {
                                    AnnMutiJson annMutiJson = new AnnMutiJson();
                                    annMutiJson.type = a.annType;
                                    annMutiJson.courseName = c.courseName;
                                    annMutiJson.courseId = c.courseId;
                                    annMutiJson.content = a.content;
                                    annMutiJson.annId = a.annId;
                                    annMutiList.Add(annMutiJson);
                                    welcomeJson.annList.Add(annMutiJson);
                                }
                            }
                        }
                    }
                }
            }
            //return welcomeJson;
            return annMutiList;
        }

        // PUT api/Welcome/5
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

        // POST api/Welcome
        public HttpResponseMessage PostAnnouncement(ReadJsonPost annChecked)
        {
            if (ModelState.IsValid)
            {
                if (AuthController.isValidUser(annChecked.stuName, annChecked.password))
                {
                    IQueryable<Read> readOut =
                        from r in db.Reads
                        where r.annId == annChecked.annId && r.stuName == annChecked.stuName
                        orderby r.readId
                        select r;
                    //List<Read> readList = new List<Read>();
                    //readList = readOut.ToList<Read>();
                    //修改数据
                    foreach (Read r in readOut)
                    {
                        r.read = "true";
                    }
                    ///将修改操作提交到数据库中
                    //db.SubmitChanges();
                    //db.Reads.Add(announcement);
                    //db.Reads.u
                    db.SaveChanges();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, annChecked);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = annChecked.stuName }));
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState); //invalid user
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState); //invalid post
            }
        }

        // DELETE api/Welcome/5
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