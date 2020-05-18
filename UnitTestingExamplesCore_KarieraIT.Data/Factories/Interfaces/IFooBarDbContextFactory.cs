namespace UnitTestingExamplesCore_KarieraIT.Data.Factories.Interfaces
{
    public interface IFooBarDbContextFactory<out T> where T : IFooBarDbContext
    {
        T Create();
    }
}
