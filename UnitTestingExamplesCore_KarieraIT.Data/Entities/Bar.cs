namespace UnitTestingExamplesCore_KarieraIT.Data.Entities
{
    public class Bar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FooId { get; set; }
        public Foo Foo { get; set; }
    }
}
