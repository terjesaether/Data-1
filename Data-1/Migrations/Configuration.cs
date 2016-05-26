namespace Data_1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data_1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Data_1.Models.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data_1.Models.MovieContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var genres = Enum.GetValues(typeof(MovieGenre))
                .Cast<MovieGenre>()
                .Select(g => new Genre { Id = (int)g, Name = g.ToString() })
                .ToArray();
            
            context.Genres.AddOrUpdate(
                g => g.Id,
                genres);
            context.SaveChanges(); 

                // g => g.Name,
                //new Genre { Name = "Action"},
                //new Genre { Name = "Drama"},
                //new Genre { Name = "Sci-Fi"},
                //new Genre { Name = "Fantasy"}
                //    );

        }
    }
}
