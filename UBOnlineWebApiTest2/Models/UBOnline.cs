using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UBOnlineWebApiTest2.Models
{
    public class Course
    {
        [Required]
        [Key]
        public string courseId { get; set; }
        [Required]
        public string courseName { get; set; }
        [Required]
        public string time { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public string proName { get; set; }
    }

    public class Student
    {
        [Required]
        [Key]
        public string stuName { get; set; }
        [Required]
        public string password { get; set; }
    }

    public class Register
    {
        [Required]
        [Key]
        public string regId { get; set; }
        [Required]
        public string stuName { get; set; } // FK
        [Required]
        public string courseId { get; set; } // FK
        [Required]
        public string taken { get; set; }
        [Required]
        public string finalGrade { get; set; }
    }

    public class File
    {
        [Required]
        [Key]
        public string fileId { get; set; }
        [Required]
        public string fileName { get; set; }
        [Required]
        public string courseId { get; set; }
        [Required]
        public string fileType { get; set; } // video,handout,homework
        [Required]
        public string fileLink { get; set; }
    }

    public class Assignment
    {
        [Required]
        [Key]
        public string asmId { get; set; }
        [Required]
        public string courseId { get; set; } // FK
        [Required]
        public string fileId { get; set; } // FK
        [Required]
        public string stuName { get; set; } // FK
        [Required]
        public string submitted { get; set; }
        [Required]
        public string grade { get; set; }
    }

    public class Professor
    {
        [Required]
        [Key]
        public string proName { get; set; }
        [Required]
        public string proEmail { get; set; }
        [Required]
        public string proPhone { get; set; }
        [Required]
        public string proOffice { get; set; }
    }

    public class Announcement
    {
        [Required]
        [Key]
        public string annId { get; set; }
        [Required]
        public string courseId { get; set; }
        [Required]
        public string annType { get; set; }
        [Required]
        public string content { get; set; }
    }

    public class Read
    {
        [Required]
        [Key]
        public string readId { get; set; }
        [Required]
        public string annId { get; set; } // FK
        [Required]
        public string stuName { get; set; } // FK
        [Required]
        public string read { get; set; }
    }
}