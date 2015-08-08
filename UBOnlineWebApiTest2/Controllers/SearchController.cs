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
    public class SearchController : ApiController
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        // GET api/Search
        public IEnumerable<File> GetFiles()
        {
            return db.Files.AsEnumerable();
        }

        //【search range】
        //Course
        //    courseId M
        //    courseName M
        //    proName M
        //File
        //    fileId
        //    courseId M
        //    fileType M
        //    fileName M
        //Announcement
        //    annId
        //    courseId M
        //    content M
        //    annType M

        //【Word allow to match】
        //cs440,cs555,cs551...
        //windows programming,advanced database...
        //AM,Lee...
        //video,assignment,file...

        // GET api/Search/5
        //public File GetFile(string id)
        public List<SearchMutiJson> GetFile(string id)
        {
            String userNameIn = id.Split('@')[0];
            String passwordIn = id.Split('@')[1];
            String keywordIn = id.Split('@')[2];

            //Find keyWord
            List<string> keyWordList = new List<string>();
            keyWordList = keywordIn.Split(' ').ToList<string>();

            //WelcomeJson welcomeJson = new WelcomeJson();
            //List<Read> readList = new List<Read>();
            List<Announcement> annList = new List<Announcement>();
            List<File> fileList = new List<File>();
            List<Course> courseList = new List<Course>();
            List<SearchMutiJson> searchMutiList = new List<SearchMutiJson>();
            List<SearchMutiJson> searchMutiListUnique = new List<SearchMutiJson>();
            if (AuthController.isValidUser(userNameIn, passwordIn))
            {
                //IQueryable<Read> ReadOut =
                //    from s in db.Reads
                //    where s.read == "false" && s.stuName == userNameIn
                //    orderby s.readId
                //    select s;
                //readList = ReadOut.ToList<Read>();
                IQueryable<Course> courseOut =
                    from s in db.Courses
                    orderby s.courseId
                    select s;
                courseList = courseOut.ToList<Course>();
                IQueryable<File> FileOut =
                    from f in db.Files
                    orderby f.fileId
                    select f;
                fileList = FileOut.ToList<File>();
                IQueryable<Announcement> AnnOut =
                    from s in db.Announcements
                    orderby s.annId
                    select s;
                annList = AnnOut.ToList<Announcement>();
                foreach (string keyWord in keyWordList)
                {
                    foreach (Course c in courseList)
                    {
                        if (c.courseId.Contains(keyWord) || keyWord.Contains("course") || keyWord.Contains("class"))
                        {
                            SearchMutiJson searchMutiJson = new SearchMutiJson();
                            searchMutiJson.type = "course";
                            searchMutiJson.id = c.courseId;
                            searchMutiJson.courseId = c.courseId;
                            searchMutiJson.courseName = c.courseName;
                            searchMutiJson.content = c.courseId;
                            searchMutiList.Add(searchMutiJson);
                        }
                        if (c.courseName.Contains(keyWord))
                        {
                            SearchMutiJson searchMutiJson = new SearchMutiJson();
                            searchMutiJson.type = "course";
                            searchMutiJson.id = c.courseId;
                            searchMutiJson.courseId = c.courseId;
                            searchMutiJson.courseName = c.courseName;
                            searchMutiJson.content = c.courseName;
                            searchMutiList.Add(searchMutiJson);
                        }
                        if (c.proName.Contains(keyWord))
                        {
                            SearchMutiJson searchMutiJson = new SearchMutiJson();
                            searchMutiJson.type = "course";
                            searchMutiJson.id = c.courseId;
                            searchMutiJson.courseId = c.courseId;
                            searchMutiJson.courseName = c.courseName;
                            searchMutiJson.content = c.proName;
                            searchMutiList.Add(searchMutiJson);
                        }
                    }
                    foreach (File f in fileList)
                    {
                        if (f.courseId.Contains(keyWord))
                        {
                            SearchMutiJson searchMutiJson = new SearchMutiJson();
                            searchMutiJson.type = f.fileType;
                            searchMutiJson.id = f.fileId;
                            searchMutiJson.courseId = f.courseId;
                            searchMutiJson.courseName = "";
                            searchMutiJson.content = f.courseId;
                            searchMutiList.Add(searchMutiJson);
                        }
                        if (f.fileName.Contains(keyWord) || keyWord.Contains("file"))
                        {
                            SearchMutiJson searchMutiJson = new SearchMutiJson();
                            searchMutiJson.type = f.fileType;
                            searchMutiJson.id = f.fileId;
                            searchMutiJson.courseId = f.courseId;
                            searchMutiJson.courseName = "";
                            searchMutiJson.content = f.fileName;
                            searchMutiList.Add(searchMutiJson);
                        }
                        if (f.fileType.Contains(keyWord))
                        {
                            SearchMutiJson searchMutiJson = new SearchMutiJson();
                            searchMutiJson.type = f.fileType;
                            searchMutiJson.id = f.fileId;
                            searchMutiJson.courseId = f.courseId;
                            searchMutiJson.courseName = "";
                            searchMutiJson.content = f.fileType;
                            searchMutiList.Add(searchMutiJson);
                        }
                    }
                    foreach (Announcement a in annList)
                    {
                        if (a.courseId.Contains(keyWord))
                        {
                            SearchMutiJson searchMutiJson = new SearchMutiJson();
                            searchMutiJson.type = "announcement";
                            searchMutiJson.id = a.annId;
                            searchMutiJson.content = a.courseId;
                            searchMutiJson.courseId = a.courseId;
                            searchMutiJson.courseName = "";
                            searchMutiList.Add(searchMutiJson);
                        }
                        if (a.content.Contains(keyWord) || keyWord.Contains("announcement"))
                        {
                            SearchMutiJson searchMutiJson = new SearchMutiJson();
                            searchMutiJson.type = "announcement";
                            searchMutiJson.id = a.annId;
                            searchMutiJson.content = a.content;
                            searchMutiJson.courseId = a.courseId;
                            searchMutiJson.courseName = "";
                            searchMutiList.Add(searchMutiJson);
                        }
                        if (a.annType.Contains(keyWord))
                        {
                            SearchMutiJson searchMutiJson = new SearchMutiJson();
                            searchMutiJson.type = "announcement";
                            searchMutiJson.id = a.annId;
                            searchMutiJson.content = a.annType;
                            searchMutiJson.courseId = a.courseId;
                            searchMutiJson.courseName = "";
                            searchMutiList.Add(searchMutiJson);
                        }
                    }
                }

                // delete duplicated item
                List<string> itemIdTypeListUnique = new List<string>();
                foreach (SearchMutiJson sjm in searchMutiList)
                {
                    if (!itemIdTypeListUnique.Contains<string>(sjm.id + sjm.type))
                    {
                        itemIdTypeListUnique.Add(sjm.id + sjm.type);
                        searchMutiListUnique.Add(sjm);
                    }
                }

                //foreach (Read r in readList)
                //{
                //    foreach (Announcement a in annList)
                //    {
                //        if (a.annId == r.annId)
                //        {
                //            foreach (Course c in courseList)
                //            {
                //                if (c.courseId == a.courseId)
                //                {
                //                    SearchMutiJson searchMutiJson = new SearchMutiJson();
                //                    searchMutiJson.type = a.annType;
                //                    searchMutiJson.id = c.courseId;
                //                    searchMutiJson.content = a.content;
                //                    searchMutiList.Add(searchMutiJson);
                //                    //welcomeJson.annList.Add(annMutiJson);
                //                }
                //            }
                //        }
                //    }
                //}
            }
            //return welcomeJson;
            //return annMutiList;
            //return searchMutiList;
            return searchMutiListUnique;
        }

        // PUT api/Search/5
        public HttpResponseMessage PutFile(string id, File file)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != file.fileId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(file).State = EntityState.Modified;

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

        // POST api/Search
        public HttpResponseMessage PostFile(File file)
        {
            if (ModelState.IsValid)
            {
                db.Files.Add(file);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, file);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = file.fileId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Search/5
        public HttpResponseMessage DeleteFile(string id)
        {
            File file = db.Files.Find(id);
            if (file == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Files.Remove(file);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, file);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}