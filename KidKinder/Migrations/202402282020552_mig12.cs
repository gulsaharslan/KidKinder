namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Classroom_ClassroomId", "dbo.Classrooms");
            DropIndex("dbo.Students", new[] { "Classroom_ClassroomId" });
            DropTable("dbo.Students");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        ClassroomId = c.String(),
                        Gender = c.String(),
                        Classroom_ClassroomId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateIndex("dbo.Students", "Classroom_ClassroomId");
            AddForeignKey("dbo.Students", "Classroom_ClassroomId", "dbo.Classrooms", "ClassroomId");
        }
    }
}
