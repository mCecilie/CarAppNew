using CarAppNew.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAppNew
{
    internal class ElectricCar : Car, IInsurable, ISellable
    {
        protected double BatteryCapacity { get; private set; }
        public double Kmperwh { get; }

        private double _price;

        // når man bruger => vil den opdatere sig med værdien, så Price kigger ALTID på _price når den bliver kaldt og er ALTID det samme
        public double Price => _price;

        public string RegistrationNumber => LicensePlate;

        private double Fuelpris = 0.1;

        public ElectricCar(string brand, string model, int year, string licensePlate, double kmperwh, double batteryCapacity, int price)
                : base(brand, model, year, licensePlate, FuelType.Electric, kmperwh, batteryCapacity)
        {
            this._price = price;
            // this.batteryLevel = batteryCapacity; //HVORFOR SKAL VI BRUGE DEN?????
            this.Kmperwh = kmperwh;
            this.BatteryCapacity = batteryCapacity;
        }

        public override double CalculateTrip(double fuelused)
        {
            return fuelused * Fuelpris; 
        }
        public override void UpdateEnergyLevel(double km)
        {
            fuelLevel -= km / Kmperwh;
        }
        
        public void Charge()
        {
            this.fuelLevel = BatteryCapacity; 
            
        }

        public double GetInsuranceRate()
        {
            return 12;
        }

        public string GetSalesSummary()
        {
            return $"Bilen er en ElectricCar koster {Price} og har en insurance rate på {GetInsuranceRate()} og har licenseplate {LicensePlate}";
        }
    }
}
