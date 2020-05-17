using Moq;
using Moq.Protected;
using NUnit.Framework;
using UnitTestingExamplesCore_KarieraIT.Services;
using UnitTestingExamplesCore_KarieraIT.Services.Interfaces;
using UnitTestingExamplesCore_KarieraIT.Tests.FakeObjects;

namespace UnitTestingExamplesCore_KarieraIT.Tests
{
    public class ServiceTests
    {   
        [TestCase(1.0, 1.0, TestName = "Calculate_PositiveValue_InputValue")]
        [TestCase(0.0, 0.0, TestName = "Calculate_Zero_Zero")]
        [TestCase(-1.0, 0.0, TestName = "Calculate_NegativeValue_Zero")]
        public void CalculateTest(double inputValue, double expectedResult)
        {
            var service = new Service();

            var actualResult = service.Calculate(inputValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1.0, 5.0, 1.0, TestName = "Calculate_PositiveValueAndRandomService_InputValue")]
        [TestCase(0.0, 5.0, 5.0, TestName = "Calculate_ZeroAndRandomService_RandomValue")]
        [TestCase(-1.0, 5.0, 5.0, TestName = "Calculate_NegativeValueAndRandomService_RandomValue")]
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

        [TestCase(1.0, 1.0, TestName = "Calculate_PositiveValueAndRandomService_InputValue")]
        [TestCase(0.0, 5.0, TestName = "Calculate_ZeroAndRandomService_RandomValue")]
        [TestCase(-1.0, 5.0, TestName = "Calculate_NegativeValueAndRandomService_RandomValue")]
        public void CalculateWithFakesTest(double inputValue, double expectedResult)
        {
            var service = new Service();
            var randomService = new FakeRandomService();

            var actualResult = service.Calculate(inputValue, randomService);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1.0, 5.0, 1, 1.0, TestName = "Calculate_PositiveValueAndRandomServiceWithSeed_InputValue")]
        [TestCase(0.0, 5.0, 1, 5.0, TestName = "Calculate_ZeroAndRandomServiceWithSeed_RandomValue")]
        [TestCase(-1.0, 5.0, 1, 5.0, TestName = "Calculate_NegativeValueAndRandomServiceWithSeed_RandomValue")]
        public void CalculateTest(double inputValue, double randomValue, int seed, double expectedResult)
        {
            var service = new Service();
            var randomServiceMock = new Mock<IRandomService>();
            randomServiceMock
                .Setup(randomService => randomService.GetRandomValue(seed))
                .Returns(randomValue);

            var actualResult = service.Calculate(inputValue, randomServiceMock.Object, seed);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1.0, 5.0, 1.0, TestName = "Calculate_PositiveValueAndRandomServiceWithSeed_InputValue")]
        [TestCase(0.0, 5.0, 5.0, TestName = "Calculate_ZeroAndRandomServiceWithSeed_RandomValue")]
        [TestCase(-1.0, 5.0, 5.0, TestName = "Calculate_NegativeValueAndRandomServiceWithSeed_RandomValue")]
        public void CalculateWithSeedTest(double inputValue, double randomValue, double expectedResult)
        {
            var service = new Service();
            var randomServiceMock = new Mock<IRandomService>();
            randomServiceMock
                .Setup(randomService => randomService.GetRandomValue(It.IsAny<int>()))
                .Returns(randomValue);

            var actualResult = service.Calculate(inputValue, randomServiceMock.Object, default);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1.0, 0, TestName = "Calculate_PositiveValueAndRandomService_GetRandomValueNotInvoked")]
        [TestCase(0.0, 1, TestName = "Calculate_ZeroAndRandomService_GetRandomValueInvokedOnce")]
        [TestCase(-1.0, 1, TestName = "Calculate_NegativeValueAndRandomService_GetRandomValueInvokedOnce")]
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

        [TestCase(1.0, 0, TestName = "Calculate_PositiveValueAndRandomService_GetRandomValueNotInvoked")]
        [TestCase(0.0, 1, TestName = "Calculate_ZeroAndRandomService_GetRandomValueInvokedOnce")]
        [TestCase(-1.0, 1, TestName = "Calculate_NegativeValueAndRandomService_GetRandomValueInvokedOnce")]
        public void CalculateLooseInvocationTest(double inputValue, int expectedResult)
        {
            var service = new Service();
            var randomServiceMock = new Mock<IRandomService>();

            service.Calculate(inputValue, randomServiceMock.Object);

            randomServiceMock.Verify(randomService => randomService.GetRandomValue(), Times.Exactly(expectedResult));
        }

        [TestCase(1.0, 0, TestName = "Calculate_PositiveValueAndRandomService_GetRandomValueNotInvoked")]
        [TestCase(0.0, 1, TestName = "Calculate_ZeroAndRandomService_GetRandomValueInvokedOnce")]
        [TestCase(-1.0, 1, TestName = "Calculate_NegativeValueAndRandomService_GetRandomValueInvokedOnce")]
        public void CalculateInvocationWithFakesTest(double inputValue, int expectedResult)
        {
            var service = new Service();
            var randomService = new FakeRandomService();

            service.Calculate(inputValue, randomService);
            var actualResult = randomService.GetRandomValueInvocationCount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1.0, 0, TestName = "Calculate_PositiveValueAndRandomServiceWithSeed_GetRandomValueNotInvoked")]
        [TestCase(0.0, 1, TestName = "Calculate_ZeroAndRandomServiceWithSeed_GetRandomValueInvokedOnce")]
        [TestCase(-1.0, 1, TestName = "Calculate_NegativeValueAndRandomServiceWithSeed_GetRandomValueInvokedOnce")]
        public void CalculateInvocationTest(double inputValue, int expectedResult)
        {
            var service = new Service();
            var randomServiceMock = new Mock<IRandomService>();

            service.Calculate(inputValue, randomServiceMock.Object);

            randomServiceMock.Verify(randomService => randomService.GetRandomValue(), Times.Exactly(expectedResult));
        }

        [TestCase(1.0, 1, 0, TestName = "FullyRandomCalculate_PositiveValue_GetRandomValueInvokedOnceWithIsNegativeFlagSetToFalse")]
        [TestCase(0.0, 0, 1, TestName = "FullyRandomCalculate_Zero_GetRandomValueInvokedOnceWithIsNegativeFlagSetToTrue")]
        [TestCase(-1.0, 0, 1, TestName = "FullyRandomCalculate_NegativeValue_GetRandomValueInvokedOnceWithIsNegativeFlagSetToTrue")]
        public void FullyRandomCalculateInvocationTest(double inputValue, int expectedGetRandomValueInvocationCount, int expectedGetRandomValueNegativeInvocationCount)
        {
            var service = new Service();
            var randomServiceMock = new Mock<IRandomService>();

            var actualResult = service.FullyRandomCalculate(inputValue, randomServiceMock.Object, default);

            randomServiceMock
                .Verify(randomService => randomService.GetRandomValue(It.Is<RandomOptions>(options => !options.IsNegative)), Times.Exactly(expectedGetRandomValueInvocationCount));
            randomServiceMock
                .Verify(randomService => randomService.GetRandomValue(It.Is<RandomOptions>(options => options.IsNegative)), Times.Exactly(expectedGetRandomValueNegativeInvocationCount));
        }

        [TestCase(1.0, 5.0, 5.0, TestName = "CalculateWithFormula_PositiveValue_InputValue")]
        [TestCase(0.0, 5.0, 0.0, TestName = "CalculateWithFormula_Zero_ApplyFormulaValue")]
        [TestCase(-1.0, 5.0, 0.0, TestName = "CalculateWithFormula_Negative_ApplyFormulaValue")]
        public void CalculateWithFormulaTest(double inputValue, double applyFormulaResult, double expectedResult)
        {
            var serviceMock = new Mock<Service> { CallBase = true };

            serviceMock
                .Setup(service => service.ApplyFormula(It.IsAny<double>()))
                .Returns(applyFormulaResult);                

            var actualResult = serviceMock.Object.CalculateWithFormula(inputValue);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}