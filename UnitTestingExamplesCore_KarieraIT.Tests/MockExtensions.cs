using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Moq;
using UnitTestingExamplesCore_KarieraIT.Data;

namespace UnitTestingExamplesCore_KarieraIT.Tests
{
    public static class MockExtensions
    {
        private static DbSet<T> GetQueryableMockDbSet<T>(ICollection<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(set => set.Provider).Returns(queryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(set => set.Expression).Returns(queryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(set => set.ElementType).Returns(queryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(set => set.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSetMock.Setup(set => set.Add(It.IsAny<T>())).Callback<T>(sourceList.Add);
            dbSetMock.Setup(set => set.Remove(It.IsAny<T>())).Callback<T>(entity => sourceList.Remove(entity));
            return dbSetMock.Object;
        }

        public static void SetupEntityCollection<T, T2>(this Mock<T2> contextMock, Expression<Func<T2, DbSet<T>>> mockedCollection, ICollection<T> returnCollection) where T : class where T2 : class, IFooBarDbContext
        {
            contextMock.Setup(mockedCollection).Returns(GetQueryableMockDbSet(returnCollection));
            contextMock.Setup(context => context.Set<T>()).Returns(GetQueryableMockDbSet(returnCollection));
            contextMock.Setup(context => context.Set<T>().Add(It.IsAny<T>())).Callback<T>(returnCollection.Add);
            contextMock.Setup(context => context.Set<T>().Remove(It.IsAny<T>())).Callback<T>(entity => returnCollection.Remove(entity));

        }
    }
}
