namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookASeats", "ClassroomId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookASeats", "ClassroomId");
            AddForeignKey("dbo.BookASeats", "ClassroomId", "dbo.Classrooms", "ClassroomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookASeats", "ClassroomId", "dbo.Classrooms");
            DropIndex("dbo.BookASeats", new[] { "ClassroomId" });
            DropColumn("dbo.BookASeats", "ClassroomId");
        }
    }
}
