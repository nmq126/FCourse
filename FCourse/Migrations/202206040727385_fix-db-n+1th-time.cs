namespace FCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdbn1thtime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserSection", "PausedAt", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserSection", "PausedAt", c => c.String());
        }
    }
}
