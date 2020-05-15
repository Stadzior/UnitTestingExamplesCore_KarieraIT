using UnitTestingExamplesCore_KarieraIT.Services.Interfaces;

namespace UnitTestingExamplesCore_KarieraIT.Tests.FakeObjects
{
    public class FakeRandomService : IRandomService
    {
        public int GetRandomValueInvocationCount { get; private set; }

        public void ClearCounter()
            => GetRandomValueInvocationCount = 0;

        public double GetRandomValue()
        {
            GetRandomValueInvocationCount++;
            return 5.0;
        }
    }
}
