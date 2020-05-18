using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UnitTestingExamplesCore_KarieraIT.Data;
using UnitTestingExamplesCore_KarieraIT.Services;

namespace UnitTestingExamplesCore_KarieraIT
{
    public class Program
    {
        public static void Main()
        {
            var service = new Service();
            var randomService = new RandomService();
            Console.WriteLine(service.Calculate(19.93));
            Console.WriteLine(service.Calculate(19.93, randomService));
            Console.WriteLine(service.Calculate(19.93, randomService, 123));
            Console.WriteLine(service.FullyRandomCalculate(19.93, randomService, 123));
            Console.WriteLine(service.FullyRandomCalculate(-19.93, randomService, 123));
            Console.WriteLine(service.CalculateWithFormula(19.93));
            Console.WriteLine(service.CalculateWithEnvironmentDefault(0.0));

            using var context = new FooBarDbContext();
            var bars = context.Bars
                .Where(bar => bar.FooId < 3)
                .Include(bar => bar.Foo);

            foreach (var bar in bars)
                Console.WriteLine($"BAR id:{bar.Id}, name:{bar.Name}, foo:{bar.Foo.Name}");
        }
    }
}
