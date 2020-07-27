namespace Student_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Field",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Student",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    BirthDate = c.DateTime(nullable: false, storeType: "date"),
                    GovernorateId = c.Int(nullable: false),
                    NeighborhoodId = c.Int(),
                    FieldId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Neighborhood", t => t.NeighborhoodId)
                .ForeignKey("dbo.Governorate", t => t.GovernorateId)
                .ForeignKey("dbo.Field", t => t.FieldId)
                .Index(t => t.GovernorateId)
                .Index(t => t.NeighborhoodId)
                .Index(t => t.FieldId);

            CreateTable(
                "dbo.Governorate",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Neighborhood",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    GovernorateId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Governorate", t => t.GovernorateId)
                .Index(t => t.GovernorateId);

            CreateTable(
                "dbo.StudentTeacher",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    StudentId = c.Int(nullable: false),
                    TeacherId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId);

            CreateTable(
                "dbo.Teacher",
                c => new
                {
                    ID = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    BirthDate = c.DateTime(nullable: false, storeType: "date"),
                })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Student", "FieldId", "dbo.Field");
            DropForeignKey("dbo.StudentTeacher", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentTeacher", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Student", "GovernorateId", "dbo.Governorate");
            DropForeignKey("dbo.Neighborhood", "GovernorateId", "dbo.Governorate");
            DropForeignKey("dbo.Student", "NeighborhoodId", "dbo.Neighborhood");
            DropIndex("dbo.StudentTeacher", new[] { "TeacherId" });
            DropIndex("dbo.StudentTeacher", new[] { "StudentId" });
            DropIndex("dbo.Neighborhood", new[] { "GovernorateId" });
            DropIndex("dbo.Student", new[] { "FieldId" });
            DropIndex("dbo.Student", new[] { "NeighborhoodId" });
            DropIndex("dbo.Student", new[] { "GovernorateId" });
            DropTable("dbo.Teacher");
            DropTable("dbo.StudentTeacher");
            DropTable("dbo.Neighborhood");
            DropTable("dbo.Governorate");
            DropTable("dbo.Student");
            DropTable("dbo.Field");
        }
    }
}
