using System.Collections.Generic;
using UnitTestingExamplesCore_KarieraIT.Data.Entities;

namespace UnitTestingExamplesCore_KarieraIT.Services.Interfaces
{
    public interface IBarService
    {
        IList<Bar> GetSpecificBars();
    }
}
