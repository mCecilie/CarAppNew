using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp.Core.Interfaces
{
    public interface ISellable
    {

        double Price { get; }

        string GetSalesSummary();

    }
}
