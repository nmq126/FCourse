namespace FCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Course", "Description", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Course", "Detail", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Section", "Name", c => c.String(nullable: false, storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Section", "Name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Course", "Detail", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Course", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
