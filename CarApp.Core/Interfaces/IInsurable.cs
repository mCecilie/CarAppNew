using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp.Core.Interfaces
{
    public interface IInsurable
    {
        string RegistrationNumber { get; }

        double GetInsuranceRate();
        double Price { get; }
    }
}
