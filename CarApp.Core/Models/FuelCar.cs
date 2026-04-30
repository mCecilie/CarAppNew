using CarApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp.Core.Models
{
    public class FuelCar : Car, IInsurable, ISellable
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
        public override string ToString()

        {

            return

            $"FuelCar,{Brand},{Model},{Year},{LicensePlate},{TankCapacity},{KmPerLiter},{Price}";

        }

        public static FuelCar FromString(string data)

        {

            string[] parts = data.Split(',');

            // parts[0] = "FuelCar" (typen — bruges ikke her)

            // parts[1] = Brand

            // parts[2] = Model

            // parts[3] = Year

            // parts[4] = LicensePlate

            // parts[5] = TankCapacity

            // parts[6] = KmPerLiter

            return new FuelCar(

            brand: parts[1],

            model: parts[2],

            year: int.Parse(parts[3]),

            licensePlate: parts[4],

            kmPerLiter: double.Parse(parts[5]),
            tankCapacity: double.Parse(parts[6]),

            price: int.Parse(parts[7])

            );

        }
    }
}
