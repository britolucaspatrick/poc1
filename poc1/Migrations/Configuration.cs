namespace poc1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<poc1.poc1Entities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "poc1.poc1Entities";
        }

        protected override void Seed(poc1.poc1Entities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
