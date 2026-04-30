using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp.Core.Models
{
    public class Brintbil : Car
    {
        protected double TankCapacity { get; private set; }
        public double DieselForbrug { get; }
        private double Fuelpris = 11;

        public Brintbil(string brand, string model, int year, string licensePlate, double dieselForbrug, double tankCapacity)
                : base(brand, model, year, licensePlate, FuelType.Diesel, dieselForbrug, tankCapacity)
        {
            // this.batteryLevel = batteryCapacity; //HVORFOR SKAL VI BRUGE DEN?????
            this.DieselForbrug = dieselForbrug;
            this.TankCapacity = tankCapacity;
        }

        public override double CalculateTrip(double fuelused)
        {
            return fuelused * Fuelpris;
        }

        public override void UpdateEnergyLevel(double km)
        {
            fuelLevel -= km / DieselForbrug;
        }

        public void Charge()
        {
            this.fuelLevel = TankCapacity;

        }
    }
}
