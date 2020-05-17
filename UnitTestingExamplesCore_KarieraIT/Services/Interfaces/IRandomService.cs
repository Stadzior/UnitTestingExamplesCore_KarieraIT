namespace UnitTestingExamplesCore_KarieraIT.Services.Interfaces
{
    public interface IRandomService
    {
        double GetRandomValue();
        double GetRandomValue(int seed);
    }
}
