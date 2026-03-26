using System;
using System.Collections.Generic;
using System.Text;

namespace CarAppNew.Interfaces
{
    internal interface IInsurable
    {
        string RegistrationNumber { get; }

        double GetInsuranceRate();
        double Price { get; }
    }
}
