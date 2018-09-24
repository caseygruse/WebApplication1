namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedusername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Username");
        }
    }
}
