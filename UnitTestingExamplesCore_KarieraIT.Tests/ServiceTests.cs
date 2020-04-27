using Moq;
using NUnit.Framework;

namespace UnitTestingExamplesCore_KarieraIT.Tests
{
    public class ServiceTests
    {
        [TestCase(1.0, 1.0, TestName = "Calculate_PositiveValue_InputValuePlusRandomValue")]
        [TestCase(0.0, 5.0, TestName = "Calculate_Zero_RandomValue")]
        [TestCase(-1.0, 5.0, TestName = "Calculate_NegativeValue_RandomValue")]
        public void CalculateTest(double inputValue, double expectedResult)
        {
            //Arrange
            var service = new Service();

            var randomValue = 5.0;
            var randomServiceMock = new Mock<IRandomService>();
            randomServiceMock
                .Setup(randomService => randomService.GetRandomValue())
                .Returns(randomValue);

            //Act
            var actualResult = service.Calculate(inputValue, randomServiceMock.Object);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}