using UnitTestingExamplesCore_KarieraIT.Services.Interfaces;

namespace UnitTestingExamplesCore_KarieraIT.Tests.FakeObjects
{
    public class FakeRandomService : IRandomService
    {
        public double GetRandomValue() => 5.0;
    }
}
