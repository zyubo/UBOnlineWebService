namespace UBOnlineWebApiTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backToOneExam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UBOnlineExams", "A", c => c.Boolean(nullable: false));
            AddColumn("dbo.UBOnlineExams", "B", c => c.Boolean(nullable: false));
            AddColumn("dbo.UBOnlineExams", "C", c => c.Boolean(nullable: false));
            AddColumn("dbo.UBOnlineExams", "D", c => c.Boolean(nullable: false));
            DropTable("dbo.UBOnlineExams");
        }
        
        public override void Down()
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
            
            DropColumn("dbo.UBOnlineExams", "D");
            DropColumn("dbo.UBOnlineExams", "C");
            DropColumn("dbo.UBOnlineExams", "B");
            DropColumn("dbo.UBOnlineExams", "A");
        }
    }
}
