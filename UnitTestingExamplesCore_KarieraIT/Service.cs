namespace UnitTestingExamplesCore_KarieraIT
{
    public class Service : IService
    {
        public double Calculate(double inputValue, IRandomService randomService)
            => inputValue > 0.0 ? inputValue : randomService.GetRandomValue();
    }
}
