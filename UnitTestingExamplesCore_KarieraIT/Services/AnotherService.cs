using UnitTestingExamplesCore_KarieraIT.Services.Interfaces;

namespace UnitTestingExamplesCore_KarieraIT.Services
{
    public class AnotherService : IService
    {
        public double Calculate(double inputValue)
            => inputValue > 20.0 ? inputValue : 0.0;

        public double Calculate(double inputValue, IRandomService randomService)
            => inputValue > 20.0 ? inputValue : randomService.GetRandomValue();

        public double Calculate(double inputValue, IRandomService randomService, int seed)
            => inputValue > 20.0 ? inputValue : randomService.GetRandomValue(seed);
    }
}
