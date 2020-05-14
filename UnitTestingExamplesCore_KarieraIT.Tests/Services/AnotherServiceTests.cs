using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using UnitTestingExamplesCore_KarieraIT.Services;
using UnitTestingExamplesCore_KarieraIT.Services.Interfaces;
using UnitTestingExamplesCore_KarieraIT.Tests.FakeObjects;

namespace UnitTestingExamplesCore_KarieraIT.Tests
{
    public class AnotherServiceTests
    {
        [TestCase(1.0, 1.0, TestName = "Calculate_PositiveValue_InputValuePlusRandomValue")]
        [TestCase(0.0, 5.0, TestName = "Calculate_Zero_RandomValue")]
        [TestCase(-1.0, 5.0, TestName = "Calculate_NegativeValue_RandomValue")]
        public void CalculateTest(double inputValue, double expectedResult)
        {
            var service = new Service();
            var randomService = new FakeRandomService();

            var actualResult = service.Calculate(inputValue, randomService);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
