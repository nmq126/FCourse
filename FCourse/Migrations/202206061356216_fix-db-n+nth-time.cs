namespace FCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdbnnthtime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Thumbnail", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Thumbnail");
        }
    }
}
