using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingExamplesCore_KarieraIT.Domain.Entities
{
    public class Bar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Foo Foo { get; set; }
    }
}
