using System;

namespace UnitTestingExamplesCore_KarieraIT
{
    public class Program
    {
        public static IService Service { get; set; }
        public static void Main()
        {
            Service = new Service();
            Console.WriteLine(Service.Calculate(19.93));
        }
    }
}
