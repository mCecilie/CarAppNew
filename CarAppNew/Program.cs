namespace CarAppNew
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            // Opret en ny bil
            FuelCar myCar = new FuelCar("Toyota", "Corolla", 2020, "AB12345", 22.5,200);
            ElectricCar Elbil = new ElectricCar("Toyota", "Corolla", 2020, "AB12345", 22.5, 100);
            myCar.TurnOnEngine();
            Elbil.TurnOnEngine();
            // Opretter ture – alle er fuldt initialiseret via konstruktøren
            List<Trip> tripsFuelCar = new List<Trip>
            {
            new Trip(myCar, 50, DateTime.Now, DateTime.Now.AddHours(1)),
            new Trip(myCar, 30, DateTime.Now, DateTime.Now.AddMinutes(30)),
            new Trip(myCar, 100, DateTime.Now, DateTime.Now.AddHours(2)),

            };
            List<Trip> tripsElbil = new List<Trip>

            // Trip-objekter oprettes med alle nødvendige data, og Car-objektet er en del af konstruktionen
            {
                new Trip(Elbil, 100, DateTime.Now, DateTime.Now.AddHours(2))
            };



            // Drive tilføjer én tur ad gangen og tjekker bil-tilhørsforhold
            Console.WriteLine("===Trips fuel car");
            foreach (var trip in tripsFuelCar)
            {
                myCar.Drive(trip);
                myCar.UpdateEnergyLevel(trip.Distance);
                Console.WriteLine($"{trip.GetTripDetails()}");
            }

            Console.WriteLine("\n\n===Trips el car===");
            foreach (var trip in tripsElbil)
            {
                Elbil.Drive(trip);
                Elbil.UpdateEnergyLevel(trip.Distance);
                Console.WriteLine($"Trip med fuelcar:{trip.GetTripDetails()}");
            }

            Elbil.Charge();
            Console.WriteLine($"Elbil ny charge: {Elbil.fuelLevel}");
            Console.WriteLine("\n\n===Trips el car===");
            foreach (var trip in tripsElbil)
            {
                Elbil.Drive(trip);
                Elbil.UpdateEnergyLevel(trip.Distance); // bør nok ligges over i drive funktionen
                Console.WriteLine($"Trip med elbil:{trip.GetTripDetails()}");
            }

            myCar.refuel();
            Console.WriteLine($"fuelcar ny charge: {myCar.fuelLevel}");

            List<Car> cars = new List<Car>(); 
            cars.Add(new FuelCar("Toyota", "Corolla", 2020, "AB12345", 50.0, 18.0)); 
            cars.Add(new ElectricCar("Tesla", "Model 3", 2022, "EL99999", 75.0, 6.5)); 
            cars.Add(new Brintbil("Toyota", "Corolla", 2020, "AB12345", 16.5, 300));
            foreach (Car car in cars) 
            { 
                car.TurnOnEngine(); 
                Trip trip = new Trip(car, 60, DateTime.Now, DateTime.Now.AddHours(1)); 
                car.Drive(trip);
                car.UpdateEnergyLevel(trip.Distance);
                Console.WriteLine($"{car.Brand} odometer: {car.Odometer} km km i tanken tilbage: {car.fuelLevel} pris: {car.CalculateTrip(trip.CalculateFuelUsed()):F2}");
            }



        }
    }
}
