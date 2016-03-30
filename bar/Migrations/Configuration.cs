namespace bar.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<bar.bar_BD>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "bar.bar_BD";
        }

     
    }
}
