using Moq;
using NUnit.Framework;
using UnitTestingExamplesCore_KarieraIT.Services;
using UnitTestingExamplesCore_KarieraIT.Services.Interfaces;

namespace UnitTestingExamplesCore_KarieraIT.Tests
{
    public class ServiceTests
    {
        [TestCase(1.0, 1.0, TestName = "Calculate_PositiveValue_InputValuePlusRandomValue")]
        [TestCase(0.0, 5.0, TestName = "Calculate_Zero_RandomValue")]
        [TestCase(-1.0, 5.0, TestName = "Calculate_NegativeValue_RandomValue")]
        public void CalculateTest(double inputValue, double expectedResult)
        {
            var service = new Service();

            const double randomValue = 5.0;
            var randomServiceMock = new Mock<IRandomService>();
            randomServiceMock
                .Setup(randomService => randomService.GetRandomValue())
                .Returns(randomValue);

            var actualResult = service.Calculate(inputValue, randomServiceMock.Object);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}