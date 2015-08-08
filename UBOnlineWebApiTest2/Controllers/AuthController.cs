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
using System.Web.Providers.Entities;
using UBOnlineWebApiTest2.Models;

// http://stackoverflow.com/questions/9594229/accessing-session-using-asp-net-web-api

namespace UBOnlineWebApiTest2.Controllers
{
    public class AuthController : ApiController
    {
        private static UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        public static bool isValidUser(string username, string password)
        {
            UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();
            IQueryable<Student> stuOut =
                from s in db.Students
                where s.stuName == username && s.password == password
                orderby s.stuName
                select s;
            if (stuOut.Count<Student>() == 0)
                return false;
            else
                return true;
        }

        // GET api/Auth
        public IEnumerable<Student> GetStudents()
        {
            return db.Students.AsEnumerable();
        }

        // GET api/Auth/5
        public Boolean GetStudent(string id)
        //public List<Student> GetStudent(string id)
        {
            String userNameIn = id.Split('@')[0];
            String passwordIn = id.Split('@')[1];
            //List<Student> stuList = new List<Student>();
            //if (AuthController.isValidUser(userNameIn, passwordIn))
            //{
            //    IQueryable<Student> stuOut =
            //        from s in db.Students
            //        where userNameIn == s.stuName && s.password == passwordIn
            //        orderby s.stuName
            //        select s;
            //    stuList = stuOut.ToList<Student>();
            //}
            ////return stuList;
            return AuthController.isValidUser(userNameIn, passwordIn);
        }

        // PUT api/Auth/5
        public HttpResponseMessage PutStudent(string id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != student.stuName)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(student).State = EntityState.Modified;

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

        // POST api/Auth
        public HttpResponseMessage PostStudent(Student student)
        {
            UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();
            if (ModelState.IsValid)
            {
                //db.Students.Add(student);
                //db.SaveChanges();

                IQueryable<Student> stuOut =
                    from s in db.Students
                    where (s.stuName == student.stuName && s.password == student.password)
                    orderby s.stuName
                    select s;

                if (stuOut.Count<Student>()!=0)
                {
                    //HttpContext.Current.Session["USERNAME"] = stuOut.ToList<Student>().ElementAt<Student>(0).stuName;
                    //SessionFacade.USERNAME = stuOut.ToList<Student>().ElementAt<Student>(0).stuName;
                    //Console.WriteLine(SessionFacade.USERNAME);
                    //Application["USERNAME"] = stuOut.ToList<Student>().ElementAt<Student>(0).stuName;
                    Global.USERSIN.Add(stuOut.ToList<Student>().ElementAt<Student>(0).stuName);
                }

                if (stuOut != null && stuOut.Count<Student>() != 0)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, student.stuName);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = student.stuName }));
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Auth/5
        public HttpResponseMessage DeleteStudent(string id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Students.Remove(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}