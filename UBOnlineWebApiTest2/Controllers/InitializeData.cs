using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UBOnlineWebApiTest2.Models;

namespace UBOnlineWebApiTest2.Controllers
{
    public class InitializeData
    {
        public static String uniqueIdTime(ref int counter)
        {
            counter += 1;
            return
                System.DateTime.Now.Millisecond.ToString() +
                counter.ToString();
        }

        public static void Insert(UBOnlineWebApiTest2Context db)
        {
            int counter = 0;
            //Course course1 = new Course();
            //Course course2 = new Course();
            //Course course3 = new Course();
                //Course course4 = new Course();
                //Course course5 = new Course();
                //Course course6 = new Course();
                //Course course7 = new Course();
            //Assignment asm1 = new Assignment(); // relationship between student and assignment
            //Assignment asm2 = new Assignment();
            //Assignment asm3 = new Assignment();
            //Assignment asm4 = new Assignment();
            //File file1 = new File();
            //File file2 = new File();
            //File file3 = new File();
            //File file4 = new File();
            //File file5 = new File();
            //File file6 = new File();
            //File file7 = new File();
            //File file8 = new File();
            //File file9 = new File();
                //File file10 = new File();
                //File file11 = new File();
                //File file12 = new File();
                //File file13 = new File();
            //Register grade1 = new Register();
            //Register grade2 = new Register();
            //Register grade3 = new Register();
            //Register grade4 = new Register();
            //Register grade5 = new Register();
            //Student student1 = new Student();
            //Student student2 = new Student();
            //Announcement anno1 = new Announcement();
            //Announcement anno2 = new Announcement();
            //Announcement anno3 = new Announcement();
            //Announcement anno4 = new Announcement();
            //Announcement anno5 = new Announcement();
            //Announcement anno6 = new Announcement();
            //Announcement anno7 = new Announcement();
            //Announcement anno8 = new Announcement();
            //Announcement anno9 = new Announcement();
            //Professor pro1 = new Professor();
            //Professor pro2 = new Professor();
            //Read read1 = new Read();
            //Read read2 = new Read();
            //Read read3 = new Read();
            //Read read4 = new Read();
            //Read read5 = new Read();
            //Read read6 = new Read();
            //Read read7 = new Read();
            //Read read8 = new Read();
            //Read read9 = new Read();
            //Read read10 = new Read();
            //Read read11 = new Read();
            //Read read12 = new Read();
            //Read read13 = new Read();
            //Read read14 = new Read();
            //Read read15 = new Read();
            //Read read16 = new Read();
            //Read read17 = new Read();
            //Read read18 = new Read();

            //course1.courseId = "cs440";
            //course1.courseName = "windows programming";
            //course1.location = "M308";
            //course1.proName = "AM";
            //course1.time = "11-00";

            //course2.courseId = "cs555";
            //course2.courseName = "web development";
            //course2.location = "M305";
            //course2.proName = "AM";
            //course2.time = "12-00";

            //course3.courseId = "cs551";
            //course3.courseName = "Advanced database";
            //course3.location = "M208";
            //course3.proName = "Lee";
            //course3.time = "06-30";

            //student1.stuName = "user1";
            //student1.password = "111";

            //student2.stuName = "user2";
            //student2.password = "222";

            //pro1.proName = "AM";
            //pro1.proEmail = "AM@bridgeport.edu";
            //pro1.proOffice = "tech220";
            //pro1.proPhone = "2034567894";

            //pro2.proName = "Lee";
            //pro2.proEmail = "Lee@bridgeport.edu";
            //pro2.proOffice = "tech120";
            //pro2.proPhone = "2034567893";

            //asm1.asmId = "asm" + uniqueIdTime(ref counter);
            //asm1.courseId = "cs440";
            //asm1.fileId = "cs440assignment1";
            //asm1.grade = "20/20";
            //asm1.stuName = "user1";
            //asm1.submitted = "true";

            //asm2.asmId = "asm" + uniqueIdTime(ref counter);
            //asm2.courseId = "cs555";
            //asm2.fileId = "cs555assignment1";
            //asm2.grade = "none";
            //asm2.stuName = "user1";
            //asm2.submitted = "true";

            //asm3.asmId = "asm" + uniqueIdTime(ref counter);
            //asm3.courseId = "cs440";
            //asm3.fileId = "cs440assignment1";
            //asm3.grade = "none";
            //asm3.stuName = "user2";
            //asm3.submitted = "false";

            //asm4.asmId = "asm" + uniqueIdTime(ref counter);
            //asm4.courseId = "cs551";
            //asm4.fileId = "cs551assignment1";
            //asm4.grade = "18/20";
            //asm4.stuName = "user2";
            //asm4.submitted = "true";

            //file1.fileId = "cs440video1";
            //file1.courseId = "cs440";
            //file1.fileLink = "http://file.video/video1.3gp";
            //file1.fileName = "video1";
            //file1.fileType = "video";

            //file2.fileId = "cs440handout1";
            //file2.courseId = "cs440";
            //file2.fileLink = "http://file.handout/file.doc";
            //file2.fileName = "handout1";
            //file2.fileType = "handout";

            //file3.fileId = "cs440assignment1";
            //file3.courseId = "cs440";
            //file3.fileLink = "http://file.assignment/hw1.doc";
            //file3.fileName = "assignment1";
            //file3.fileType = "assignment";

            //file4.fileId = "cs555video1";
            //file4.courseId = "cs555";
            //file4.fileLink = "http://file.video/video1.3gp";
            //file4.fileName = "video1";
            //file4.fileType = "video";

            //file5.fileId = "cs555handout1";
            //file5.courseId = "cs555";
            //file5.fileLink = "http://file.handout/file.doc";
            //file5.fileName = "handout1";
            //file5.fileType = "handout";

            //file6.fileId = "cs555assignment1";
            //file6.courseId = "cs555";
            //file6.fileLink = "http://file.assignment/hw1.doc";
            //file6.fileName = "assignment1";
            //file6.fileType = "assignment";

            //file7.fileId = "cs551video1";
            //file7.courseId = "cs551";
            //file7.fileLink = "http://file.video/video1.3gp";
            //file7.fileName = "video1";
            //file7.fileType = "video";

            //file8.fileId = "cs551handout1";
            //file8.courseId = "cs551";
            //file8.fileLink = "http://file.handout/file.doc";
            //file8.fileName = "handout1";
            //file8.fileType = "handout";

            //file9.fileId = "cs551assignment1";
            //file9.courseId = "cs551";
            //file9.fileLink = "http://file.assignment/hw1.doc";
            //file9.fileName = "assignment1";
            //file9.fileType = "assignment";

                //file10.fileId = "cs440video2";
                //file10.courseId = "cs440";
                //file10.fileLink = "http://download.wavetlan.com/SVV/Media/HTTP/3GP/Media-Convert/Media-Convert_test1_3GPv4_H263_xbit_352x288_AR1.22_15fps_KFx_374kbps_AMRNB_Mono_8000Hz_12.2kbps.3gp";
                //file10.fileName = "video2";
                //file10.fileType = "video";

            //grade1.regId = "reg" + uniqueIdTime(ref counter);
            //grade1.courseId = "cs440";
            //grade1.finalGrade = "A";
            //grade1.stuName = "user1";
            //grade1.taken = "true";

            //grade2.regId = "reg" + uniqueIdTime(ref counter);
            //grade2.courseId = "cs555";
            //grade2.finalGrade = "none";
            //grade2.stuName = "user1";
            //grade2.taken = "true";

            //grade3.regId = "reg" + uniqueIdTime(ref counter);
            //grade3.courseId = "cs440";
            //grade3.finalGrade = "none";
            //grade3.stuName = "user2";
            //grade3.taken = "true";

            //grade4.regId = "reg" + uniqueIdTime(ref counter);
            //grade4.courseId = "cs551";
            //grade4.finalGrade = "B";
            //grade4.stuName = "user2";
            //grade4.taken = "true";

            //grade5.regId = "reg" + uniqueIdTime(ref counter);
            //grade5.courseId = "cs555";
            //grade5.finalGrade = "none";
            //grade5.stuName = "user2";
            //grade5.taken = "false";

            //anno1.annId = "cs440assignment1";
            //anno1.annType = "assignment";
            //anno1.content = "assignment 1 has been posted";
            //anno1.courseId = "cs440";

            //anno2.annId = "cs555assignment1";
            //anno2.annType = "assignment";
            //anno2.content = "assignment 1 has been posted";
            //anno2.courseId = "cs555";

            //anno3.annId = "cs551assignment1";
            //anno3.annType = "assignment";
            //anno3.content = "assignment 1 has been posted";
            //anno3.courseId = "cs551";

            //anno4.annId = "cs440handout1";
            //anno4.annType = "handout";
            //anno4.content = "handout 1 has been posted";
            //anno4.courseId = "cs440";

            //anno5.annId = "cs555handout1";
            //anno5.annType = "handout";
            //anno5.content = "handout 1 has been posted";
            //anno5.courseId = "cs555";

            //anno6.annId = "cs551handout1";
            //anno6.annType = "handout";
            //anno6.content = "handout 1 has been posted";
            //anno6.courseId = "cs551";

            //anno7.annId = "cs440video1";
            //anno7.annType = "video";
            //anno7.content = "video 1 has been posted";
            //anno7.courseId = "cs440";

            //anno8.annId = "cs555video1";
            //anno8.annType = "video";
            //anno8.content = "video 1 has been posted";
            //anno8.courseId = "cs555";

            //anno9.annId = "cs551video1";
            //anno9.annType = "video";
            //anno9.content = "video 1 has been posted";
            //anno9.courseId = "cs551";

            //read1.readId = "read" + uniqueIdTime(ref counter);
            //read1.annId = "cs440assignment1";
            //read1.read = "false";
            //read1.stuName = "user1";

            //read2.readId = "read" + uniqueIdTime(ref counter);
            //read2.annId = "cs555assignment1";
            //read2.read = "false";
            //read2.stuName = "user1";

            //read3.readId = "read" + uniqueIdTime(ref counter);
            //read3.annId = "cs551assignment1";
            //read3.read = "false";
            //read3.stuName = "user1";

            //read4.readId = "read" + uniqueIdTime(ref counter);
            //read4.annId = "cs440handout1";
            //read4.read = "false";
            //read4.stuName = "user1";

            //read5.readId = "read" + uniqueIdTime(ref counter);
            //read5.annId = "cs555handout1";
            //read5.read = "false";
            //read5.stuName = "user1";

            //read6.readId = "read" + uniqueIdTime(ref counter);
            //read6.annId = "cs551handout1";
            //read6.read = "false";
            //read6.stuName = "user1";

            //read7.readId = "read" + uniqueIdTime(ref counter);
            //read7.annId = "cs440video1";
            //read7.read = "false";
            //read7.stuName = "user1";

            //read8.readId = "read" + uniqueIdTime(ref counter);
            //read8.annId = "cs555video1";
            //read8.read = "false";
            //read8.stuName = "user1";

            //read9.readId = "read" + uniqueIdTime(ref counter);
            //read9.annId = "cs551video1";
            //read9.read = "false";
            //read9.stuName = "user1";

            //read10.readId = "read" + uniqueIdTime(ref counter);
            //read10.annId = "cs440assignment1";
            //read10.read = "false";
            //read10.stuName = "user2";

            //read11.readId = "read" + uniqueIdTime(ref counter);
            //read11.annId = "cs555assignment1";
            //read11.read = "false";
            //read11.stuName = "user2";

            //read12.readId = "read" + uniqueIdTime(ref counter);
            //read12.annId = "cs551assignment1";
            //read12.read = "false";
            //read12.stuName = "user2";

            //read13.readId = "read" + uniqueIdTime(ref counter);
            //read13.annId = "cs440handout1";
            //read13.read = "false";
            //read13.stuName = "user2";

            //read14.readId = "read" + uniqueIdTime(ref counter);
            //read14.annId = "cs555handout1";
            //read14.read = "false";
            //read14.stuName = "user2";

            //read15.readId = "read" + uniqueIdTime(ref counter);
            //read15.annId = "cs551handout1";
            //read15.read = "false";
            //read15.stuName = "user2";

            //read16.readId = "read" + uniqueIdTime(ref counter);
            //read16.annId = "cs440video1";
            //read16.read = "false";
            //read16.stuName = "user2";

            //read17.readId = "read" + uniqueIdTime(ref counter);
            //read17.annId = "cs555video1";
            //read17.read = "false";
            //read17.stuName = "user2";

            //read18.readId = "read" + uniqueIdTime(ref counter);
            //read18.annId = "cs551video1";
            //read18.read = "false";
            //read18.stuName = "user2";

            if (false)
            {
                //db.Courses.Remove(course1);
                //db.Courses.Remove(course2);
                //db.Courses.Remove(course3);
                //db.Assignments.Remove(asm1);
                //db.Assignments.Remove(asm2);
                //db.Assignments.Remove(asm3);
                //db.Assignments.Remove(asm4);
                //db.Files.Remove(file1);
                //db.Files.Remove(file2);
                //db.Files.Remove(file3);
                //db.Files.Remove(file4);
                //db.Files.Remove(file5);
                //db.Files.Remove(file6);
                //db.Files.Remove(file7);
                //db.Files.Remove(file8);
                //db.Files.Remove(file9);
                //db.Registers.Remove(grade1);
                //db.Registers.Remove(grade2);
                //db.Registers.Remove(grade3);
                //db.Registers.Remove(grade4);
                //db.Registers.Remove(grade5);
                //db.Students.Remove(student1);
                //db.Students.Remove(student2);
                //db.Announcements.Remove(anno1);
                //db.Announcements.Remove(anno2);
                //db.Announcements.Remove(anno3);
                //db.Announcements.Remove(anno4);
                //db.Announcements.Remove(anno5);
                //db.Announcements.Remove(anno6);
                //db.Announcements.Remove(anno7);
                //db.Announcements.Remove(anno8);
                //db.Announcements.Remove(anno9);
                //db.Professors.Remove(pro1);
                //db.Professors.Remove(pro2);
                //db.Reads.Remove(read1);
                //db.Reads.Remove(read2);
                //db.Reads.Remove(read3);
                //db.Reads.Remove(read4);
                //db.Reads.Remove(read5);
                //db.Reads.Remove(read6);
                //db.Reads.Remove(read7);
                //db.Reads.Remove(read8);
                //db.Reads.Remove(read9);
                //db.Reads.Remove(read10);
                //db.Reads.Remove(read11);
                //db.Reads.Remove(read12);
                //db.Reads.Remove(read13);
                //db.Reads.Remove(read14);
                //db.Reads.Remove(read15);
                //db.Reads.Remove(read16);
                //db.Reads.Remove(read17);
                //db.Reads.Remove(read18);
            }

            //db.Courses.Add(course1);
            //db.Courses.Add(course2);
            //db.Courses.Add(course3);
            //db.Assignments.Add(asm1);
            //db.Assignments.Add(asm2);
            //db.Assignments.Add(asm3);
            //db.Assignments.Add(asm4);
            //db.Files.Add(file1);
            //db.Files.Add(file2);
            //db.Files.Add(file3);
            //db.Files.Add(file4);
            //db.Files.Add(file5);
            //db.Files.Add(file6);
            //db.Files.Add(file7);
            //db.Files.Add(file8);
            //db.Files.Add(file9);
                //db.Files.Add(file10);
            //db.Registers.Add(grade1);
            //db.Registers.Add(grade2);
            //db.Registers.Add(grade3);
            //db.Registers.Add(grade4);
            //db.Registers.Add(grade5);
            //db.Students.Add(student1);
            //db.Students.Add(student2);
            //db.Announcements.Add(anno1);
            //db.Announcements.Add(anno2);
            //db.Announcements.Add(anno3);
            //db.Announcements.Add(anno4);
            //db.Announcements.Add(anno5);
            //db.Announcements.Add(anno6);
            //db.Announcements.Add(anno7);
            //db.Announcements.Add(anno8);
            //db.Announcements.Add(anno9);
            //db.Professors.Add(pro1);
            //db.Professors.Add(pro2);
            //db.Reads.Add(read1);
            //db.Reads.Add(read2);
            //db.Reads.Add(read3);
            //db.Reads.Add(read4);
            //db.Reads.Add(read5);
            //db.Reads.Add(read6);
            //db.Reads.Add(read7);
            //db.Reads.Add(read8);
            //db.Reads.Add(read9);
            //db.Reads.Add(read10);
            //db.Reads.Add(read11);
            //db.Reads.Add(read12);
            //db.Reads.Add(read13);
            //db.Reads.Add(read14);
            //db.Reads.Add(read15);
            //db.Reads.Add(read16);
            //db.Reads.Add(read17);
            //db.Reads.Add(read18);

                //db.SaveChanges();
        }
    }
}