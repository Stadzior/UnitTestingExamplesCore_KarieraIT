using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingExamplesCore_KarieraIT.Domain.Entities
{
    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Bar> Bars { get; set; }
    }
}
