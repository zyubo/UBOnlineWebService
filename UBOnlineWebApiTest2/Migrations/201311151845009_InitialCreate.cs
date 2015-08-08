namespace UBOnlineWebApiTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        asmId = c.String(nullable: false, maxLength: 128),
                        courseId = c.String(nullable: false),
                        fileId = c.String(nullable: false),
                        stuName = c.String(nullable: false),
                        submitted = c.String(nullable: false),
                        grade = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.asmId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        courseId = c.String(nullable: false, maxLength: 128),
                        courseName = c.String(nullable: false),
                        time = c.String(nullable: false),
                        location = c.String(nullable: false),
                        proName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.courseId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        fileId = c.String(nullable: false, maxLength: 128),
                        fileName = c.String(nullable: false),
                        courseId = c.String(nullable: false),
                        fileType = c.String(nullable: false),
                        fileLink = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.fileId);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        regId = c.String(nullable: false, maxLength: 128),
                        stuName = c.String(nullable: false),
                        courseId = c.String(nullable: false),
                        taken = c.String(nullable: false),
                        finalGrade = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.regId);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        proName = c.String(nullable: false, maxLength: 128),
                        proEmail = c.String(nullable: false),
                        proPhone = c.String(nullable: false),
                        proOffice = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.proName);
            
            CreateTable(
                "dbo.Reads",
                c => new
                    {
                        readId = c.String(nullable: false, maxLength: 128),
                        annId = c.String(nullable: false),
                        stuName = c.String(nullable: false),
                        read = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.readId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        stuName = c.String(nullable: false, maxLength: 128),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.stuName);
            
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        annId = c.String(nullable: false, maxLength: 128),
                        courseId = c.String(nullable: false),
                        annType = c.String(nullable: false),
                        content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.annId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Announcements");
            DropTable("dbo.Students");
            DropTable("dbo.Reads");
            DropTable("dbo.Professors");
            DropTable("dbo.Registers");
            DropTable("dbo.Files");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
        }
    }
}
