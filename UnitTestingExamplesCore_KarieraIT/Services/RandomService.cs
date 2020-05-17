using System;
using UnitTestingExamplesCore_KarieraIT.Services.Interfaces;

namespace UnitTestingExamplesCore_KarieraIT.Services
{
    public class RandomService : IRandomService
    {
        public double GetRandomValue()
            => new Random().NextDouble();

        public double GetRandomValue(int seed)
            => new Random(seed).NextDouble();
    }
}
