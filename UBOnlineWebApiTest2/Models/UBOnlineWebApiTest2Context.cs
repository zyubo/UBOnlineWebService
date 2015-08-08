using System.Data.Entity;

namespace UBOnlineWebApiTest2.Models
{
    public class UBOnlineWebApiTest2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<UBOnlineWebApiTest2.Models.UBOnlineWebApiTest2Context>());

        public UBOnlineWebApiTest2Context() : base("name=UBOnlineWebApiTest2Context")
        {
        }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Register> Registers { get; set; }

        public DbSet<Professor> Professors { get; set; }

        public DbSet<Read> Reads { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<UBOnlineExam> UBOnlineExam { get; set; }
    }
}
