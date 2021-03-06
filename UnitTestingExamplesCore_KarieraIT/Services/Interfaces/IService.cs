﻿namespace UnitTestingExamplesCore_KarieraIT.Services.Interfaces
{
    public interface IService
    {
        double Calculate(double inputValue);
        double Calculate(double inputValue, IRandomService randomService);
        double Calculate(double inputValue, IRandomService randomService, int seed);
    }
}
