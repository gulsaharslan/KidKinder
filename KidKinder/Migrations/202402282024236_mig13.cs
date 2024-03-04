namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Gender = c.String(),
                        ClassroomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .Index(t => t.ClassroomId);
            
            DropColumn("dbo.Classrooms", "EnrollNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classrooms", "EnrollNumber", c => c.Int(nullable: false));
            DropForeignKey("dbo.Students", "ClassroomId", "dbo.Classrooms");
            DropIndex("dbo.Students", new[] { "ClassroomId" });
            DropTable("dbo.Students");
        }
    }
}
