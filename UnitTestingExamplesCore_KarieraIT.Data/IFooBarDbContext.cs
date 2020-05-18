using System;
using Microsoft.EntityFrameworkCore;
using UnitTestingExamplesCore_KarieraIT.Data.Entities;

namespace UnitTestingExamplesCore_KarieraIT.Data
{
    public interface IFooBarDbContext : IDisposable
    {
        DbSet<Foo> Foos { get; set; }
        DbSet<Bar> Bars { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
