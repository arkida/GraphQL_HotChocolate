using GraphQL_HotChocolate.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace GraphQL_HotChocolate.DAL
{
    public class DatabaseContext: DbContext
    { 

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<SwapiPerson> SwapiPerson { get; set; }
        public DbSet<SwapiPeople> SwapiPeople { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

       
            builder.Entity<SwapiPeople>();

            // The Vehicles property
            builder.Entity<SwapiPerson>()
            .Property(e => e.Vehicles)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            // The Films property
            builder.Entity<SwapiPerson>()
            .Property(e => e.Films)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            // The Species property
            builder.Entity<SwapiPerson>()
            .Property(e => e.Species)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            // The Starships property
            builder.Entity<SwapiPerson>()
            .Property(e => e.Starships)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

        }
        }
}
