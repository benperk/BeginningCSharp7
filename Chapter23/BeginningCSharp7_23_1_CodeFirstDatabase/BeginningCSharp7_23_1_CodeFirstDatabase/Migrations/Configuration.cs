namespace BeginningCSharp7_23_1_CodeFirstDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeginningCSharp7_23_1_CodeFirstDatabase.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BeginningCSharp7_23_1_CodeFirstDatabase.BookContext";
        }

        protected override void Seed(BeginningCSharp7_23_1_CodeFirstDatabase.BookContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
