namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "WorkTime", c => c.String());
            AddColumn("dbo.Classrooms", "EnrollNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Classrooms", "EnrollNumber");
            DropColumn("dbo.Teachers", "WorkTime");
        }
    }
}
