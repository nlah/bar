namespace bar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bar_BD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "qualification", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "qualification");
        }
    }
}
