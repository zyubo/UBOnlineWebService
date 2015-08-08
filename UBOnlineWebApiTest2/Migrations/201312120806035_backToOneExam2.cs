namespace UBOnlineWebApiTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backToOneExam2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UBOnlineExams",
                c => new
                {
                    titleId = c.String(nullable: false, maxLength: 128),
                    A = c.Boolean(nullable: false),
                    B = c.Boolean(nullable: false),
                    C = c.Boolean(nullable: false),
                    D = c.Boolean(nullable: false),
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
