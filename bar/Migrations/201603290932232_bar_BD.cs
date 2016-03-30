namespace bar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bar_BD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.orders", "date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "password", c => c.String(nullable: false));
            DropColumn("dbo.orders", "data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.orders", "data", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "password", c => c.String());
            DropColumn("dbo.orders", "date");
        }
    }
}
