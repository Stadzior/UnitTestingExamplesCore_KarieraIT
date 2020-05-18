using System;
using System.Collections.Generic;
using System.Text;
using UnitTestingExamplesCore_KarieraIT.Data.Factories.Interfaces;

namespace UnitTestingExamplesCore_KarieraIT.Data.Factories
{
    public class FooBarDbContextFactory<T> : IFooBarDbContextFactory<T> where T : IFooBarDbContext
    {
        public T Create() => (T)Activator.CreateInstance(typeof(T));
    }
}
