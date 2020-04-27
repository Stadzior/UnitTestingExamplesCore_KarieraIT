using NUnit.Framework;

namespace UnitTestingExamplesCore_KarieraIT.Tests
{
    public class ServiceTests
    {
        [TestCase(1.0, 1.0, TestName = "Calculate_PositiveValue_InputValue")]
        [TestCase(0.0, 0.0, TestName = "Calculate_Zero_Zero")]
        [TestCase(-1.0, 0.0, TestName = "Calculate_NegativeValue_Zero")]
        public void CalculateTest(double inputValue, double expectedResult)
        {
            //Arrange
            var service = new Service();

            //Act
            var actualResult = service.Calculate(inputValue);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}