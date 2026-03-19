using System;
using System.Collections.Generic;
using System.Text;

namespace CarAppNew
{
    internal class ElectricCar : Car
    {
        protected double BatteryCapacity { get; private set; }
        public double Kmperwh { get; }

        private double pris = 0.1;

        public ElectricCar(string brand, string model, int year, string licensePlate, double kmperwh, double batteryCapacity)
                : base(brand, model, year, licensePlate, FuelType.Electric, kmperwh, batteryCapacity)
        {
           // this.batteryLevel = batteryCapacity; //HVORFOR SKAL VI BRUGE DEN?????
            this.Kmperwh = kmperwh;
            this.BatteryCapacity = batteryCapacity;
        }

        public override double CalculateTrip(double fuelused)
        {
            return fuelused * pris; 
        }
        public override void UpdateEnergyLevel(double km)
        {
            fuelLevel -= km / Kmperwh;
        }
        
        public void Charge()
        {
            this.fuelLevel = BatteryCapacity; 
            
        }
    }
}
