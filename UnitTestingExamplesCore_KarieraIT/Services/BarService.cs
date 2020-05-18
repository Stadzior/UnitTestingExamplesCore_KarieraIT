using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UnitTestingExamplesCore_KarieraIT.Data;
using UnitTestingExamplesCore_KarieraIT.Data.Entities;
using UnitTestingExamplesCore_KarieraIT.Data.Factories.Interfaces;
using UnitTestingExamplesCore_KarieraIT.Services.Interfaces;

namespace UnitTestingExamplesCore_KarieraIT.Services
{
    public class BarService : IBarService
    {
        private readonly IFooBarDbContextFactory<IFooBarDbContext> _contextFactory;

        public BarService(IFooBarDbContextFactory<IFooBarDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IList<Bar> GetSpecificBars()
        {
            using var context = _contextFactory.Create();
            return context.Bars
                        .Where(bar => bar.FooId < 3)
                        .Include(bar => bar.Foo)
                        .ToList();
        }
    }
}
