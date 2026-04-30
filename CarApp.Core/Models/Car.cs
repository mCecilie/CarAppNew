using System;
using System.Collections.Generic;

namespace CarApp.Core.Models
{
    public abstract class Car
    {
        //Opretter mine variabler og properties for Car klassen.
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string LicensePlate { get; private set; }
        public FuelType FuelType { get; protected set; }
        public double KmPerLiter { get; protected set; }
        public double Odometer { get; private set; }
        public double fuelLevel { get; protected set; }

        // Opretter en privat liste af Trip objekter, som vil holde styr på alle ture foretaget med bilen.
        private List<Trip> _trips = new List<Trip>();
        private Engine _engine;

        //Opretter en kontruktør for Car klassen, som tager alle nødvendige parametre for at initialisere en bil.
        public Car(string brand, string model, int year, string licensePlate, FuelType fuelType, double Enhederperliter, double FuelLevel)
        {
            Brand = brand;
            Model = model;
            Year = year;
            LicensePlate = licensePlate;
            FuelType = fuelType;
            KmPerLiter = Enhederperliter;
            fuelLevel = FuelLevel;
            _engine = new Engine();
        }


        //Tjekker om bilen er tændt eller slukket ved at kalde på Engine klassen.
        public void TurnOnEngine() => _engine.Start();
        public void TurnOffEngine() => _engine.Stop();

        // Abstrakt metode: underklassen definerer, hvordan energi opdateres public abstract void UpdateEnergyLevel(double km);
        public abstract void UpdateEnergyLevel(double km);
        public abstract double CalculateTrip(double distance);

        //metode til at registrere en ny køretur for bilen.
        //Den tager et Trip objekt som parameter og opdaterer bilens odometer og tilføjer til liste over køreture.
        public void Drive(Trip newTrip)
        {
            if (newTrip.Car == this && fuelLevel > 0)
            {
                fuelLevel -= newTrip.CalculateFuelUsed();
                Odometer += newTrip.Distance;
                _trips.Add(newTrip);
            }

            else
            {
                Console.WriteLine("Fejl: Denne tur tilhører ikke denne bil.");
            }
        }

        //Metode til at hente alle ture foretaget med bilen.
        public List<Trip> GetTrips() => _trips;

        //Indsætter listen af ture og returnerer en ny liste med kun de ture, der matcher den angivne dato.
        public List<Trip> GetTripsByDate(DateTime date)
        {
            List<Trip> result = new List<Trip>();
            foreach (Trip trip in _trips)
            {
                if (trip.TripDate.Date == date.Date)
                {
                    result.Add(trip);
                }
            }
            return result;
        }

        //Indsætter listen af ture og returnerer en ny liste med kun de ture, der starter inden for det angivne tidsinterval.
        public List<Trip> GetTripsInTimeInterval(DateTime start, DateTime end)
        {
            List<Trip> result = new List<Trip>();

            foreach (Trip trip in _trips)
            {
                if (trip.StartTime >= start && trip.StartTime <= end)
                {
                    result.Add(trip);
                }
            }

            return result;
        }
    }
}
