using System;

namespace UnitTestingExamplesCore_KarieraIT
{
    public class RandomService : IRandomService
    {
        public double GetRandomValue()
            => new Random().NextDouble();
    }
}
