namespace bar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bar_BD : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "login", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.Users", "login");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "login", c => c.String(nullable: false, maxLength: 100));
            AddPrimaryKey("dbo.Users", "login");
        }
    }
}
