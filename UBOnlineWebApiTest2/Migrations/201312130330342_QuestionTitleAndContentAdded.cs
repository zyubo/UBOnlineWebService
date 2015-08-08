namespace UBOnlineWebApiTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionTitleAndContentAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UBOnlineExams", "questionTitle", c => c.String());
            AddColumn("dbo.UBOnlineExams", "questionContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UBOnlineExams", "questionContent");
            DropColumn("dbo.UBOnlineExams", "questionTitle");
        }
    }
}
