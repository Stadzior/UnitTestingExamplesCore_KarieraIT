using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingExamplesCore_KarieraIT
{
    public class Service : IService
    {
        public double Calculate(double inputValue)
            => inputValue > 0.0 ? inputValue : 0.0;
    }
}
