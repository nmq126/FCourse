namespace FCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Description", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Description", c => c.String(maxLength: 50));
        }
    }
}
