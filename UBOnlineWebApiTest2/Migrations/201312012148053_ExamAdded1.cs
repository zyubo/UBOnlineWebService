namespace UBOnlineWebApiTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExamAdded1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UBOnlineExams",
                c => new
                    {
                        titleId = c.String(nullable: false, maxLength: 128),
                        comments = c.String(),
                    })
                .PrimaryKey(t => t.titleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UBOnlineExams");
        }
    }
}
