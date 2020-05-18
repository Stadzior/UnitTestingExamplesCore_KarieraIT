using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UnitTestingExamplesCore_KarieraIT.Data;
using UnitTestingExamplesCore_KarieraIT.Data.Entities;
using UnitTestingExamplesCore_KarieraIT.Services.Interfaces;

namespace UnitTestingExamplesCore_KarieraIT.Services
{
    public class BarService : IBarService
    {
        public IEnumerable<Bar> GetSpecificBars()
        {
            using var context = new FooBarDbContext();
            return context.Bars
                .Where(bar => bar.FooId < 3)
                .Include(bar => bar.Foo);
        }
    }
}
