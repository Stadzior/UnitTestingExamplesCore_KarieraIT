namespace UnitTestingExamplesCore_KarieraIT.Data.Entities
{
    public class Bar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FooId { get; set; }
        public Foo Foo { get; set; }

        public override bool Equals(object obj)
            => obj is Bar bar &&
               Id == bar.Id &&
               Name == bar.Name &&
               FooId == bar.FooId &&
               Foo.Equals(bar.Foo);

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ FooId;
                hashCode = (hashCode * 397) ^ (Foo != null ? Foo.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
