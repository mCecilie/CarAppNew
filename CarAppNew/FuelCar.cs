using System;
using System.Collections.Generic;
using System.Text;

namespace CarAppNew
{
    internal class FuelCar : Car
    {

        protected double TankCapacity { get; private set; }
        public double FuelLevel { get; }
        public double KmPerLiter { get; }

        public FuelCar(string brand, string model, int year, string licensePlate, double kmPerLiter, double tankCapacity)
                : base(brand, model, year, licensePlate, FuelType.Benzin, kmPerLiter)
        { 
            TankCapacity = tankCapacity; 
            KmPerLiter = kmPerLiter; 
            FuelLevel = tankCapacity; 
        }


        public override void UpdateEnergyLevel(double km)
        {
            throw new NotImplementedException();
        }
    }
}
