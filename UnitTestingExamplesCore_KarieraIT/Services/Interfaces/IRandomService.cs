namespace UnitTestingExamplesCore_KarieraIT.Services.Interfaces
{
    public interface IRandomService
    {
        double GetRandomValue();
        double GetRandomValue(int seed);
        double GetRandomValue(int seed, bool isNegative);
    }
}
