using System.Collections.Generic;
using System.Linq;

namespace UnitTestingExamplesCore_KarieraIT.Data.Entities
{
    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Bar> Bars { get; set; }

        public override bool Equals(object obj)
            => obj is Foo foo &&
               Id == foo.Id &&
               Name == foo.Name &&
               Bars.SequenceEqual(foo.Bars);

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Bars != null ? Bars.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
