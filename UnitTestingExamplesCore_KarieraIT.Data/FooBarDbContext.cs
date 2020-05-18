using Microsoft.EntityFrameworkCore;
using UnitTestingExamplesCore_KarieraIT.Data.Entities;

namespace UnitTestingExamplesCore_KarieraIT.Data
{
    public class FooBarDbContext : DbContext, IFooBarDbContext
    {
        private const string ConnectionString = "Server=.\\MSSQL2016DEV;Database=FooBarDB;Trusted_Connection=True;";
        public DbSet<Foo> Foos { get; set; }
        public DbSet<Bar> Bars { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Foo>().HasData(
                new Foo { Id = 1, Name = "Foo1"},
                new Foo { Id = 2, Name = "Foo2"},
                new Foo { Id = 3, Name = "Foo3"},
                new Foo { Id = 4, Name = "Foo4"});

            modelBuilder.Entity<Bar>().HasData(
                new Bar { Id = 1, Name = "Bar1", FooId = 1 },
                new Bar { Id = 2, Name = "Bar2", FooId = 1 },
                new Bar { Id = 3, Name = "Bar3", FooId = 1 },
                new Bar { Id = 4, Name = "Bar4", FooId = 1 },
                new Bar { Id = 5, Name = "Bar5", FooId = 2 },
                new Bar { Id = 6, Name = "Bar6", FooId = 2 },
                new Bar { Id = 7, Name = "Bar7", FooId = 2 },
                new Bar { Id = 8, Name = "Bar8", FooId = 3 },
                new Bar { Id = 9, Name = "Bar9", FooId = 3 },
                new Bar { Id = 10, Name = "Bar10", FooId = 4 });
        }
    }
}
