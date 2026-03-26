using System;
using System.Collections.Generic;
using System.Text;

namespace CarAppNew.Interfaces
{
    public interface ISellable
    {

        double Price { get; }

        string GetSalesSummary();

    }
}
