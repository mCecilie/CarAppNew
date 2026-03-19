using System;
using System.Collections.Generic;
using System.Text;

namespace CarAppNew
{
    internal class FuelCar : Car
    {

        protected double TankCapacity { get; private set; }
        public double FuelLevel { get; private set; }

        private double pris = 14;


        public FuelCar(string brand, string model, int year, string licensePlate, double kmPerLiter, double tankCapacity)
                : base(brand, model, year, licensePlate, FuelType.Benzin, kmPerLiter, tankCapacity)
        { 
            this.TankCapacity = tankCapacity; 
            this.FuelLevel = tankCapacity; 
        }

        public override double CalculateTrip(double fuelused)
        {
            return fuelused * pris;
        }

        public override void UpdateEnergyLevel(double km)
        {
            fuelLevel -= km/KmPerLiter;
        }

        public void refuel()
        {
            fuelLevel = TankCapacity;

        }
    }
}
