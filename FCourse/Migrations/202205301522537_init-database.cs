namespace FCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DisabledAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        CategoryId = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        Detail = c.String(nullable: false, maxLength: 255),
                        Duration = c.Double(nullable: false),
                        LevelId = c.String(nullable: false, maxLength: 10),
                        Rating = c.Double(nullable: false),
                        Thumbnail = c.String(nullable: false, maxLength: 255),
                        Price = c.Double(nullable: false),
                        Discount = c.Int(nullable: false),
                        TeacherId = c.String(nullable: false, maxLength: 10),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DisabledAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Level", t => t.LevelId, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.LevelId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Level",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Section",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        CourseId = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 10),
                        Type = c.Int(nullable: false),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        Duration = c.Double(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderId = c.String(nullable: false, maxLength: 10),
                        CourseId = c.String(nullable: false, maxLength: 10),
                        UnitPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.CourseId })
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        UserId = c.String(maxLength: 10),
                        TotalPrice = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DisabledAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 255),
                        PasswordHash = c.String(maxLength: 255),
                        Salt = c.String(maxLength: 255),
                        Role = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DisabledAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        Name = c.String(maxLength: 50),
                        Thumbnail = c.String(storeType: "ntext"),
                        Description = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserCourse",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 10),
                        CourseId = c.String(nullable: false, maxLength: 10),
                        Grade = c.String(),
                        IsFinished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CourseId })
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.UserSection",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 10),
                        SectionId = c.String(nullable: false, maxLength: 10),
                        PausedAt = c.String(),
                        IsFinished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.SectionId })
                .ForeignKey("dbo.Section", t => t.SectionId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSection", "UserId", "dbo.User");
            DropForeignKey("dbo.UserSection", "SectionId", "dbo.Section");
            DropForeignKey("dbo.UserCourse", "UserId", "dbo.User");
            DropForeignKey("dbo.UserCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Course", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.OrderDetail", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Section", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Course", "LevelId", "dbo.Level");
            DropForeignKey("dbo.Course", "CategoryId", "dbo.Category");
            DropIndex("dbo.UserSection", new[] { "SectionId" });
            DropIndex("dbo.UserSection", new[] { "UserId" });
            DropIndex("dbo.UserCourse", new[] { "CourseId" });
            DropIndex("dbo.UserCourse", new[] { "UserId" });
            DropIndex("dbo.Order", new[] { "UserId" });
            DropIndex("dbo.OrderDetail", new[] { "CourseId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Section", new[] { "CourseId" });
            DropIndex("dbo.Course", new[] { "TeacherId" });
            DropIndex("dbo.Course", new[] { "LevelId" });
            DropIndex("dbo.Course", new[] { "CategoryId" });
            DropTable("dbo.UserSection");
            DropTable("dbo.UserCourse");
            DropTable("dbo.Teacher");
            DropTable("dbo.User");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Section");
            DropTable("dbo.Level");
            DropTable("dbo.Course");
            DropTable("dbo.Category");
        }
    }
}
