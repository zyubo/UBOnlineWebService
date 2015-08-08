using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UBOnlineWebApiTest2.Models
{
    public class StudentJson
    {
        public string other { get; set; }
        public List<Student> stuList { get; set; }
    }

    public class WelcomeJson
    {
        public List<AnnMutiJson> annList { get; set; }
        public WelcomeJson()
        {
            annList = new List<AnnMutiJson>();
        }
    }
    public class AnnMutiJson
    {
        public string type { get; set; }
        public string content { get; set; }
        public string courseName { get; set; }
        public string courseId { get; set; }
        public string annId { get; set; }
    }

    public class SearchJson
    {
        public List<SearchMutiJson> searchList { get; set; }
        public SearchJson()
        {
            searchList = new List<SearchMutiJson>();
        }
    }
    public class SearchMutiJson
    {
        public string type { get; set; }
        public string id { get; set; }
        public string courseName { get; set; }
        public string courseId { get; set; }
        public string content { get; set; }
    }

    public class GradeJson
    {
        public List<GradeMutiJson> gradeList { get; set; }
        public GradeJson()
        {
            gradeList = new List<GradeMutiJson>();
        }
    }
    public class GradeMutiJson
    {
        public string courseId { get; set; }
        public string courseName { get; set; }
        public string taken { get; set; }
        public string totalGrade { get; set; }
    }

    public class CourseJson
    {
        public List<CourseMutiJson> courseList { get; set; }
        public CourseJson()
        {
            courseList = new List<CourseMutiJson>();
        }
    }
    public class CourseMutiJson
    {
        public string courseName { get; set; }
        public string professor { get; set; }
        public string courseNum { get; set; }
        public string time { get; set; }
        public string location { get; set; }
        public string taken { get; set; }
    }

    public class AssignmentJson
    {
        public List<AsmMutiJson> asmList { get; set; }
        public AssignmentJson()
        {
            asmList = new List<AsmMutiJson>();
        }
    }
    public class AsmMutiJson
    {
        public string courseName { get; set; }
        public string courseId { get; set; }
    }

    public class GradeSingleJson
    {
        public string totalGrade { get; set; }
        public List<Assignment> grade { get; set; }
        public GradeSingleJson()
        {
            grade = new List<Assignment>();
        }
    }
    public class FileSingleJson
    {
        public List<File> fileList { get; set; }
        public FileSingleJson()
        {
            fileList = new List<File>();
        }
    }
    public class AsmSingleJson
    {
        public string totalGrade { get; set; }
        public List<AsmSingleJsonElement> asmSingleList { get; set; }
        public AsmSingleJson()
        {
            asmSingleList = new List<AsmSingleJsonElement>();
        }
    }
    public class AsmSingleJsonElement
    {
        public string hwName { get; set; }
        public string link { get; set; }
        public string submitted { get; set; }
        public string score { get; set; }
    }
    public class AnnSingleJson
    {
        public List<Announcement> annSingleList { get; set; }
        public AnnSingleJson()
        {
            annSingleList = new List<Announcement>();
        }
    }
    public class ReadJsonPost
    {
        public string stuName { get; set; }
        public string password { get; set; }
        public string annId { get; set; }
    }
}