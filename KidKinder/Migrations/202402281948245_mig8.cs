namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        ClassroomId = c.String(),
                        Classroom_ClassroomId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Classrooms", t => t.Classroom_ClassroomId)
                .Index(t => t.Classroom_ClassroomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Classroom_ClassroomId", "dbo.Classrooms");
            DropIndex("dbo.Students", new[] { "Classroom_ClassroomId" });
            DropTable("dbo.Students");
        }
    }
}
