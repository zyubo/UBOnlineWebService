namespace UBOnlineWebApiTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AToA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UBOnlineExams", "A", c => c.Boolean(nullable: false));
            AddColumn("dbo.UBOnlineExams", "B", c => c.Boolean(nullable: false));
            AddColumn("dbo.UBOnlineExams", "C", c => c.Boolean(nullable: false));
            AddColumn("dbo.UBOnlineExams", "D", c => c.Boolean(nullable: false));
            DropColumn("dbo.UBOnlineExams", "A");
            DropColumn("dbo.UBOnlineExams", "B");
            DropColumn("dbo.UBOnlineExams", "C");
            DropColumn("dbo.UBOnlineExams", "D");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UBOnlineExams", "D", c => c.Boolean(nullable: false));
            AddColumn("dbo.UBOnlineExams", "C", c => c.Boolean(nullable: false));
            AddColumn("dbo.UBOnlineExams", "B", c => c.Boolean(nullable: false));
            AddColumn("dbo.UBOnlineExams", "A", c => c.Boolean(nullable: false));
            DropColumn("dbo.UBOnlineExams", "D");
            DropColumn("dbo.UBOnlineExams", "C");
            DropColumn("dbo.UBOnlineExams", "B");
            DropColumn("dbo.UBOnlineExams", "A");
        }
    }
}
