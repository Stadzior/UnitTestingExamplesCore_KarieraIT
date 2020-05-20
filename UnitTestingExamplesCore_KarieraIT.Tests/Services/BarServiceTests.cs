using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using UnitTestingExamplesCore_KarieraIT.Data;
using UnitTestingExamplesCore_KarieraIT.Data.Entities;
using UnitTestingExamplesCore_KarieraIT.Data.Factories.Interfaces;
using UnitTestingExamplesCore_KarieraIT.Services;

namespace UnitTestingExamplesCore_KarieraIT.Tests.Services
{
    public class BarServiceTests
    {
        private static readonly object[] _getSpecificBarsSource =
        {
            new TestCaseData(new List<Bar>(), new List<Bar>()).SetName("GetSpecificBars_NoData_EmptyList"),
            new TestCaseData(new List<Bar>
            {
                new Bar
                {
                    Id = 1,
                    Name = "Bar1",
                    FooId = 1,
                    Foo = new Foo
                    {
                        Id = 1,
                        Name = "Foo1",
                        Bars = new List<Bar>()
                    }
                },
                new Bar
                {
                    Id = 2,
                    Name = "Bar2",
                    FooId = 2,
                    Foo = new Foo
                    {
                        Id = 2,
                        Name = "Foo2",
                        Bars = new List<Bar>()
                    }
                },
                new Bar
                {
                    Id = 3,
                    Name = "Bar3",
                    FooId = 3,
                    Foo = new Foo
                    {
                        Id = 3,
                        Name = "Foo3",
                        Bars = new List<Bar>()
                    }
                }
            }, new List<Bar>
            {
                new Bar
                {
                    Id = 1,
                    Name = "Bar1",
                    FooId = 1,
                    Foo = new Foo 
                        { 
                            Id = 1,
                            Name = "Foo1",
                            Bars = new List<Bar>()
                        }
                },
                new Bar
                {
                    Id = 2,
                    Name = "Bar2",
                    FooId = 2,
                    Foo = new Foo
                    {
                        Id = 2,
                        Name = "Foo2",
                        Bars = new List<Bar>()
                    }
                }
            }).SetName("GetSpecificBars_ThreeRecords_TwoMatchingRecords"),
        };

        [TestCaseSource(nameof(_getSpecificBarsSource))]
        public void GetSpecificBarsTest(IList<Bar> bars, IList<Bar> expectedResult)
        {
            var contextMock = new Mock<IFooBarDbContext>();
            contextMock.SetupEntityCollection(context => context.Bars, bars);

            var contextFactoryMock = new Mock<IFooBarDbContextFactory<IFooBarDbContext>>();
            contextFactoryMock
                .Setup(contextFactory => contextFactory.Create())
                .Returns(contextMock.Object);

            var barService = new BarService(contextFactoryMock.Object);

            var actualResult = barService.GetSpecificBars();

            Assert.That(expectedResult.SequenceEqual(actualResult));

            actualResult.Should().BeEquivalentTo(expectedResult);
        }
    }
}
