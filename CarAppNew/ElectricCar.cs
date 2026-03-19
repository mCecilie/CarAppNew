using System;
using System.Collections.Generic;
using System.Text;

namespace CarAppNew
{
    internal class ElectricCar : Car
    {
        protected double TankCapacity { get; private set; }
        public double FuelLevel { get; }
        public double Kmperwh { get; }

        public ElectricCar(string brand, string model, int year, string licensePlate, double kmperwh, double tankCapacity)
                : base(brand, model, year, licensePlate, FuelType.Electric, kmperwh)
        {
            TankCapacity = tankCapacity;
            Kmperwh = kmperwh;
            FuelLevel = tankCapacity;
        }


        public override void UpdateEnergyLevel(double km)
        {
            throw new NotImplementedException();
        }
    }
}
