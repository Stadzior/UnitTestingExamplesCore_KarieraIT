using Moq;
using NUnit.Framework;
using UnitTestingExamplesCore_KarieraIT.Services;

namespace UnitTestingExamplesCore_KarieraIT.Tests.Services
{
    public class RandomServiceTests
    {
        private static readonly object[] _getRandomValueSource =
        {
            new TestCaseData(new RandomOptions
            {
                Seed = 0,
                IsNegative = true
            }, 5.0, -5.0).SetName("GetRandomValue_IsNegativeSetToTrue_NegativeValueReturned"),
            new TestCaseData(new RandomOptions
            {
                Seed = 0,
                IsNegative = false
            }, 5.0, 5.0).SetName("GetRandomValue_IsNegativeSetToFalse_PositiveValueReturned")
        };

        [TestCaseSource(nameof(_getRandomValueSource))]
        public void GetRandomValueTest(RandomOptions randomOptions, double randomValue, double expectedResult)
        {
            var randomServiceMock = new Mock<RandomService> { CallBase = true };
            randomServiceMock
                .Setup(randomService => randomService.GetRandomValue(randomOptions.Seed))
                .Returns(randomValue);

            var actualResult = randomServiceMock.Object.GetRandomValue(randomOptions);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
