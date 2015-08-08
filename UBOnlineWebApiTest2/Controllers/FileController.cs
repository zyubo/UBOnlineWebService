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
    public class FileController : ApiController
    {
        private UBOnlineWebApiTest2Context db = new UBOnlineWebApiTest2Context();

        // GET api/File
        public IEnumerable<File> GetFiles()
        {
            //List<File> fileList = new List<File>();
            //string[] videoArr = new string[4];
            //videoArr[0] = "http://download.wavetlan.com/SVV/Media/HTTP/H264/Other_Media/dolphins_1600k.3gp";
            //videoArr[1] = "http://download.wavetlan.com/SVV/Media/HTTP/H264/Other_Media/dolphins_1800k.3gp";
            //videoArr[2] = "http://download.wavetlan.com/SVV/Media/HTTP/H264/Other_Media/dolphins_2000k.3gp";
            //videoArr[3] = "http://download.wavetlan.com/SVV/Media/HTTP/3GP/Media-Convert/Media-Convert_test1_3GPv4_H263_xbit_352x288_AR1.22_15fps_KFx_374kbps_AMRNB_Mono_8000Hz_12.2kbps.3gp";
            //string[] handoutArr = new string[3];
            //handoutArr[0] = "http://googledrive.com/host/0B_1wQB0nBo28eGRXM1lfOThqUkU/Blob_Tracking_Tests.doc";
            //handoutArr[1] = "http://googledrive.com/host/0B_1wQB0nBo28eGRXM1lfOThqUkU/Copyright.txt";
            //handoutArr[2] = "http://googledrive.com/host/0B_1wQB0nBo28eGRXM1lfOThqUkU/TestSeq.doc";
            //string[] assignmentArr = new string[3];
            //assignmentArr[0] = "https://googledrive.com/host/0B_1wQB0nBo28eGRXM1lfOThqUkU/opencv_cheatsheet.pdf";
            //assignmentArr[1] = "https://googledrive.com/host/0B_1wQB0nBo28eGRXM1lfOThqUkU/opencv_user.pdf";
            //assignmentArr[2] = "http://googledrive.com/host/0B_1wQB0nBo28eGRXM1lfOThqUkU/manual.pdf";
            //IQueryable<File> fileOut =
            //    from s in db.Files
            //    orderby s.fileId
            //    select s;
            //fileList = fileOut.ToList<File>();
            //int ivideo = 0;
            //int ihandout = 0;
            //int iassignment = 0;
            //foreach (File f in fileOut)
            //{
            //    if (f.fileType == "video")
            //    {
            //        f.fileLink = videoArr[ivideo];
            //        ivideo++;
            //    }
            //    if (f.fileType == "handout")
            //    {
            //        f.fileLink = handoutArr[ihandout];
            //        ihandout++;
            //    }
            //    if (f.fileType == "assignment")
            //    {
            //        f.fileLink = assignmentArr[iassignment];
            //        iassignment++;
            //    }
            //}
            //db.SaveChanges();
            return db.Files.AsEnumerable();
        }

        // GET api/File/5
        public List<File> GetFile(string id)
        {
            String userNameIn = id.Split('@')[0];
            String passwordIn = id.Split('@')[1];
            String courseIdIn = id.Split('@')[2];
            FileSingleJson fileSingleJson = new FileSingleJson();
            List<File> fileList = new List<File>();
            if (AuthController.isValidUser(userNameIn, passwordIn))
            {
                IQueryable<File> fileOut =
                    from s in db.Files
                    where courseIdIn == s.courseId && s.fileType != "assignment"
                    orderby s.fileId
                    select s;
                fileSingleJson.fileList = fileOut.ToList<File>();
                fileList = fileOut.ToList<File>();
            }
            return fileList;
        }

        // PUT api/File/5
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

        // POST api/File
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

        // DELETE api/File/5
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