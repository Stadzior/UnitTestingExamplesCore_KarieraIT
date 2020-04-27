using System;

namespace UnitTestingExamplesCore_KarieraIT
{
    public class Program
    {
        public static IService Service { get; set; }
        public static IRandomService RandomService { get; set; }

        public static void Main()
        {
            Service = new Service();
            RandomService = new RandomService();
            Console.WriteLine(Service.Calculate(19.93, RandomService));
        }
    }
}
