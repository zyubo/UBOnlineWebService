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
    public class CourseController : ApiController
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        // GET api/Course
        public IEnumerable<Course> GetCourses()
        {
            //InitializeData.Insert(db);
            return db.Courses.AsEnumerable();
        }

        //// GET api/Course/5
        //public CourseJson GetCourse(string id)
        //{
        //    String userNameIn = id.Split('@')[0];
        //    String passwordIn = id.Split('@')[1];
        //    CourseJson courseJson = new CourseJson();
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
        //            CourseMutiJson courseMutiJson = new CourseMutiJson();
        //            courseMutiJson.courseName = course.courseName;
        //            courseMutiJson.professor = course.proName;
        //            courseMutiJson.courseNum = course.courseId;
        //            courseMutiJson.time = course.time;
        //            courseMutiJson.location = course.location;
        //            courseMutiJson.taken = r.taken;
        //            courseJson.courseList.Add(courseMutiJson);
        //        }
        //    }
        //    return courseJson;
        //}

        // GET api/Course/5
        public List<CourseMutiJson> GetCourse(string id)
        {
            String userNameIn = id.Split('@')[0];
            String passwordIn = id.Split('@')[1];
            CourseJson courseJson = new CourseJson();
            List<Register> gradeList = new List<Register>();
            List<Course> courseList = new List<Course>();
            List<CourseMutiJson> courseMutiList = new List<CourseMutiJson>();
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
                            CourseMutiJson courseMutiJson = new CourseMutiJson();
                            courseMutiJson.courseName = c.courseName;
                            courseMutiJson.professor = c.proName;
                            courseMutiJson.courseNum = c.courseId;
                            courseMutiJson.time = c.time;
                            courseMutiJson.location = c.location;
                            courseMutiJson.taken = r.taken;
                            courseJson.courseList.Add(courseMutiJson);
                            courseMutiList.Add(courseMutiJson);
                        }
                    }
                }
            }
            return courseMutiList;
        }

        // PUT api/Course/5
        public HttpResponseMessage PutCourse(string id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != course.courseId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(course).State = EntityState.Modified;

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

        // POST api/Course
        public HttpResponseMessage PostCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, course);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = course.courseId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Course/5
        public HttpResponseMessage DeleteCourse(string id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Courses.Remove(course);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, course);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}