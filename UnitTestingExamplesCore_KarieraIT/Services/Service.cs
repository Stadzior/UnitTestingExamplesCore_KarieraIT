using UnitTestingExamplesCore_KarieraIT.Services.Interfaces;

namespace UnitTestingExamplesCore_KarieraIT.Services
{
    public class Service : IService
    {
        public double Calculate(double inputValue)
            => inputValue > 0.0 ? inputValue : 0.0;

        public double Calculate(double inputValue, IRandomService randomService)
            => inputValue > 0.0 ? inputValue : randomService.GetRandomValue();
    }
}
