namespace FCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropPrimaryKey("dbo.OrderDetail");
            DropPrimaryKey("dbo.Order");
            AlterColumn("dbo.OrderDetail", "OrderId", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Order", "Id", c => c.String(nullable: false, maxLength: 10));
            AddPrimaryKey("dbo.OrderDetail", new[] { "OrderId", "CourseId" });
            AddPrimaryKey("dbo.Order", "Id");
            CreateIndex("dbo.OrderDetail", "OrderId");
            AddForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropPrimaryKey("dbo.Order");
            DropPrimaryKey("dbo.OrderDetail");
            AlterColumn("dbo.Order", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.OrderDetail", "OrderId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Order", "Id");
            AddPrimaryKey("dbo.OrderDetail", new[] { "OrderId", "CourseId" });
            CreateIndex("dbo.OrderDetail", "OrderId");
            AddForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order", "Id", cascadeDelete: true);
        }
    }
}
