namespace CarAppNew
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            // Opret en ny bil
            Car myCar = new FuelCar("Toyota", "Corolla", 2020, "AB12345", 22.5,100);
            Car Elbil = new ElectricCar("Toyota", "Corolla", 2020, "AB12345", 22.5, 100);
            myCar.TurnOnEngine();
            Elbil.TurnOnEngine();
            // Opretter ture – alle er fuldt initialiseret via konstruktøren
            List<Trip> trips = new List<Trip>

            // Trip-objekter oprettes med alle nødvendige data, og Car-objektet er en del af konstruktionen
            {
            new Trip(myCar, 50, DateTime.Now, DateTime.Now.AddHours(1)),
            new Trip(myCar, 30, DateTime.Now, DateTime.Now.AddMinutes(30)),
            new Trip(myCar, 100, DateTime.Now, DateTime.Now.AddHours(2)),
            new Trip(Elbil, 100, DateTime.Now, DateTime.Now.AddHours(2))
            };

            // Drive tilføjer én tur ad gangen og tjekker bil-tilhørsforhold
            foreach (var trip in trips)
            {
                myCar.Drive(trip);
                Elbil.Drive(trip);
            }

            // Main har ansvar for udskrivningen – ikke Car
            Console.WriteLine("\n--- Alle ture ---");
            foreach (var trip in myCar.GetTrips())
            {
                Console.WriteLine(trip.GetTripDetails());
            }

            Console.WriteLine($"\nOdometer: {myCar.Odometer} km");

            Console.WriteLine("\n--- Alle ture¨el ---");
            foreach (var trip in Elbil.GetTrips())
            {
                Console.WriteLine(trip.GetTripDetails());
            }
        }
    }
}
