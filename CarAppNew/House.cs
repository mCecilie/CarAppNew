using CarAppNew.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAppNew
{
    public class House : ISellable, IInsurable

    {

        public string Address { get; }

        public int YearBuilt { get; }

        public double Price { get; }

        public string RegistrationNumber { get; }  // matrikelnummer 



        public House(string address, int yearBuilt, double price, string cadastralNumber)

        {

            Address = address;

            YearBuilt = yearBuilt;

            Price = price;

            RegistrationNumber = cadastralNumber;

        }



        public string GetSalesSummary()

        {

            return $"{Address}, opført {YearBuilt}, pris: {Price:N0} kr";

        }



        public double GetInsuranceRate()

        {

            return YearBuilt < 1980 ? 1.8 : 1.2;  // ældre huse er dyrere at forsikre 

        }

    }
}