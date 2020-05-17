﻿using NUnit.Framework;
using UnitTestingExamplesCore_KarieraIT.Services;
using UnitTestingExamplesCore_KarieraIT.Tests.FakeObjects;

namespace UnitTestingExamplesCore_KarieraIT.Tests
{
    public class AnotherServiceTests
    {
        [TestCase(1.0, 1.0, TestName = "Calculate_PositiveValue_InputValue")]
        [TestCase(0.0, 0.0, TestName = "Calculate_Zero_Zero")]
        [TestCase(-1.0, 0.0, TestName = "Calculate_NegativeValue_Zero")]
        public void CalculateTest(double inputValue, double expectedResult)
        {
            var service = new AnotherService();

            var actualResult = service.Calculate(inputValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1.0, 1.0, TestName = "Calculate_PositiveValueAndRandomService_InputValuePlusRandomValue")]
        [TestCase(0.0, 5.0, TestName = "Calculate_ZeroAndRandomService_RandomValue")]
        [TestCase(-1.0, 5.0, TestName = "Calculate_NegativeValueAndRandomService_RandomValue")]
        public void CalculateWithRandomServiceTest(double inputValue, double expectedResult)
        {
            var service = new AnotherService();
            var randomService = new FakeRandomService();

            var actualResult = service.Calculate(inputValue, randomService);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1.0, 0, TestName = "Calculate_PositiveValueAndRandomService_GetRandomValueNotInvoked")]
        [TestCase(0.0, 1, TestName = "Calculate_ZeroAndRandomService_GetRandomValueInvokedOnce")]
        [TestCase(-1.0, 1, TestName = "Calculate_NegativeValueAndRandomService_GetRandomValueInvokedOnce")]
        public void CalculateInvocationTest(double inputValue, int expectedResult)
        {
            var service = new AnotherService();
            var randomService = new FakeRandomService();

            service.Calculate(inputValue, randomService);
            var actualResult = randomService.GetRandomValueInvocationCount;

           Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
