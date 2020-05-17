using System;
using UnitTestingExamplesCore_KarieraIT.Services;

namespace UnitTestingExamplesCore_KarieraIT
{
    public class Program
    {
        public static void Main()
        {
            var service = new Service();
            var anotherService = new AnotherService();
            var randomService = new RandomService();
            Console.WriteLine(service.Calculate(19.93));
            Console.WriteLine(service.Calculate(19.93, randomService));
            Console.WriteLine(service.Calculate(19.93, randomService, 123));
            Console.WriteLine(anotherService.Calculate(19.93));
            Console.WriteLine(anotherService.Calculate(19.93, randomService));
            Console.WriteLine(anotherService.Calculate(19.93, randomService, 123));
        }
    }
}
