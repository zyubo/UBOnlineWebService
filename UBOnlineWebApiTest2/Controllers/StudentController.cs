using System;
using System.Collections;
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
using Newtonsoft.Json;
using System.Web.Script.Serialization;

//return JSON Object
//http://stackoverflow.com/questions/227624/asp-net-mvc-controller-actions-that-return-json-or-partial-html

namespace UBOnlineWebApiTest2.Controllers
{
    public class StudentController : ApiController
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        // GET api/Student
        //public IEnumerable<StudentJson> GetStudents()
        public StudentJson GetStudents()
        {
            //IQueryable<Student> stuOut =
            //    from s in db.Students
            //    //where (s.stuName == student.stuName && s.password == student.password)
            //    orderby s.stuName
            //    select s;

            IQueryable<Student> stuOut =
                from s in db.Students
                orderby s.stuName
                select s;
            //List<Student> lstu = new List<Student>();
            //lstu = stuOut.ToList<Student>();

            StudentJson sjson = new StudentJson
            {
                other = "other",
                //stuObj = new List<Student> {
                //    new Student {
                //        stuName = "stuName1",
                //        password = "password1"
                //    },
                //    new Student {
                //        stuName = "stuName2",
                //        password = "password2"
                //    },
                //    new Student {
                //        stuName = "stuName3",
                //        password = "password3"
                //    }
                //}
                stuList = stuOut.ToList<Student>()
            };
            //IQueryable<StudentJson> iqStuJson = sjson;

            //var result = new
            //{
            //    pages = 10,
            //    users = new ArrayList
            //    {
            //        new{id=1,name="2"},
            //        new{id=2,name="3"}
            //    }
            //};
            //result.users.Add(new { id = 3, name = "4" });

            //var json = new JavaScriptSerializer().Serialize(result);

            //foreach (Student s in stuOut)
            //{
            //    Console.WriteLine("stuName" + s.stuName);
            //    Console.WriteLine("password" + s.password);
            //}
            //return db.Students.AsEnumerable();
            //return stuOut.AsEnumerable();
            //return json.AsEnumerable();
            return sjson;
            //return Json(new { foo = "bar", baz = "Blech" });
        }

        // GET api/Student/5
        public Student GetStudent(string id)
        {
            //Student student = db.Students.Find(id);
            //if (student == null)
            //{
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            //}
            //String[] tmpUserArr = id.Split('@');
            String tmpUser = id.Split('@')[1];
            Student testSession = new Student();
            if (Global.USERSIN.Contains(id.Split('@')[1]))
            {
                testSession.password = "4323";
                testSession.stuName = id.Split('@')[0];
            }
            return testSession;
            //return student;
        }

        // PUT api/Student/5
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

        // POST api/Student
        public HttpResponseMessage PostStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, student);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = student.stuName }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Student/5
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