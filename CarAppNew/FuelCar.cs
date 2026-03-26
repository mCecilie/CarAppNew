using CarAppNew.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAppNew
{
    internal class FuelCar : Car, IInsurable, ISellable
    {

        protected double TankCapacity { get; private set; }
        public double FuelLevel { get; private set; }

        private double Fuelpris = 14;

        public string RegistrationNumber => LicensePlate;

        private double _price;
        public double Price => _price;

        public FuelCar(string brand, string model, int year, string licensePlate, double kmPerLiter, double tankCapacity, int price)
                : base(brand, model, year, licensePlate, FuelType.Benzin, kmPerLiter, tankCapacity)
        {
            this._price = price;
            this.TankCapacity = tankCapacity; 
            this.FuelLevel = tankCapacity; 
        }

        public override double CalculateTrip(double fuelused)
        {
            return fuelused * Fuelpris;
        }

        public override void UpdateEnergyLevel(double km)
        {
            fuelLevel -= km/KmPerLiter;
        }

        public void refuel()
        {
            fuelLevel = TankCapacity;

        }

        public double GetInsuranceRate()
        {
            return 23;
        }

        public string GetSalesSummary()
        {
            return $"Bilen er en FuelCar koster {Price} og har en insurance rate på {GetInsuranceRate()} og har licenseplate {LicensePlate}";
        }
    }
}
