using Moq;
using NUnit.Framework;
using UnitTestingExamplesCore_KarieraIT.Services;
using UnitTestingExamplesCore_KarieraIT.Services.Interfaces;

namespace UnitTestingExamplesCore_KarieraIT.Tests
{
    public class ServiceTests
    {
        [TestCase(1.0, 5.0, 1.0, TestName = "Calculate_PositiveValue_InputValuePlusRandomValue")]
        [TestCase(0.0, 5.0, 5.0, TestName = "Calculate_Zero_RandomValue")]
        [TestCase(-1.0, 5.0, 5.0, TestName = "Calculate_NegativeValue_RandomValue")]
        public void CalculateTest(double inputValue, double randomValue, double expectedResult)
        {
            var service = new Service();
            var randomServiceMock = new Mock<IRandomService>();
            randomServiceMock
                .Setup(randomService => randomService.GetRandomValue())
                .Returns(randomValue);

            var actualResult = service.Calculate(inputValue, randomServiceMock.Object);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1.0, 0, TestName = "Calculate_PositiveValue_GetRandomValueNotInvoked")]
        [TestCase(0.0, 1, TestName = "Calculate_Zero_GetRandomValueInvokedOnce")]
        [TestCase(-1.0, 1, TestName = "Calculate_NegativeValue_GetRandomValueInvokedOnce")]
        public void CalculateStrictInvocationTest(double inputValue, int expectedResult)
        {
            var service = new Service();
            var randomServiceMock = new Mock<IRandomService>(MockBehavior.Strict);
            randomServiceMock
                .Setup(randomService => randomService.GetRandomValue())
                .Returns(0.0);

            service.Calculate(inputValue, randomServiceMock.Object);
            
            randomServiceMock.Verify(randomService => randomService.GetRandomValue(), Times.Exactly(expectedResult));
        }

        [TestCase(1.0, 0, TestName = "Calculate_PositiveValue_GetRandomValueNotInvoked")]
        [TestCase(0.0, 1, TestName = "Calculate_Zero_GetRandomValueInvokedOnce")]
        [TestCase(-1.0, 1, TestName = "Calculate_NegativeValue_GetRandomValueInvokedOnce")]
        public void CalculateLooseInvocationTest(double inputValue, int expectedResult)
        {
            var service = new Service();
            var randomServiceMock = new Mock<IRandomService>();

            service.Calculate(inputValue, randomServiceMock.Object);

            randomServiceMock.Verify(randomService => randomService.GetRandomValue(), Times.Exactly(expectedResult));
        }
    }
}