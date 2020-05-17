using System;
using UnitTestingExamplesCore_KarieraIT.Services.Interfaces;

namespace UnitTestingExamplesCore_KarieraIT.Services
{
    public class Service : IService
    {
        public double Calculate(double inputValue)
            => inputValue > 0.0 ? inputValue : 0.0;

        public double Calculate(double inputValue, IRandomService randomService)
            => inputValue > 0.0 ? inputValue : randomService.GetRandomValue();

        public double Calculate(double inputValue, IRandomService randomService, int seed)
            => inputValue > 0.0 ? inputValue : randomService.GetRandomValue(seed);

        public double FullyRandomCalculate(double inputValue, IRandomService randomService, int seed)
        {
            var randomOptions = new RandomOptions 
            { 
                Seed = seed,
                IsNegative = inputValue <= 0.0
            };

            return randomService.GetRandomValue(randomOptions);
        }
        
        protected virtual double ApplyFormula(double inputValue)
            => Math.Sqrt(inputValue * 2);

        public double CalculateWithFormula(double inputValue)
            => inputValue > 0.0 ? ApplyFormula(inputValue) : 0.0;

        protected virtual double GetDefaultValue()
            => double.Parse(Environment.GetEnvironmentVariable("DefaultValue"));

        public double CalculateWithEnvironmentDefault(double inputValue)
            => inputValue > 0.0 ? inputValue : GetDefaultValue();
    }
}
