using System.Collections.Generic;

namespace UnitTestingExamplesCore_KarieraIT.Data.Entities
{
    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Bar> Bars { get; set; }
    }
}
