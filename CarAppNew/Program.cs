using CarApp.Core.Models;

using CarApp.Core.Repositories;
namespace CarAppNew
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {


            ICarRepository repo = new FileCarRepository("C:\\codeprojects\\CarAppDiaLøsning2\\CarAppNew\\cars.txt");

             
            repo.Add(new FuelCar("Toyota", "Corolla", 2022, "AB12345", 50, 18, 45000));

            repo.Add(new ElectricCar("Tesla", "Model 3", 2023, "CD67890", 75, 6.5, 380000));
            repo.Add(new FuelCar("Toyota", "Corolla", 2022, "AB12345", 50, 18, 45000));

            // Hent alle og udskriv

            foreach (Car car in repo.GetAll())

                Console.WriteLine($"{car.Brand} {car.Model} — {car.LicensePlate}");


            // Hent en specifik bil

            Car found = repo.GetByLicensePlate("AB12345");

            Console.WriteLine(found != null ? $"Fundet: {found.Brand}" : "Ikke fundet");

            //Lad os ændre den første af AB12345 bilerne
            var Newfoundcar = new FuelCar("Fiat", "Punto", 2022, "AB12345", 50, 18, 45000); // skulle gerne ændre den øverste?
            repo.Update(Newfoundcar);

            // Slet en bil og verificer

            repo.Delete("AB12345");

            Console.WriteLine($"Antal biler: {repo.GetAll().Count()}"); // 1

            














            /*
             * _______________________________________________________________
             * _______________________________________________________________
             * _______________________________________________________________
            // Opret en ny bil
            FuelCar myCar = new FuelCar("Toyota", "Corolla", 2020, "AB12345", 22.5,200, 2000);
            ElectricCar Elbil = new ElectricCar("Toyota", "Corolla", 2020, "AB12345", 22.5, 100, 5000);
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

            myCar.refuel();
            Console.WriteLine($"fuelcar ny charge: {myCar.fuelLevel}");

            FuelCar fc = new FuelCar("Toyota", "Corolla", 2022, "AB12345", 12, 45000, 2000);
            ElectricCar ec = new ElectricCar("Tesla", "Model 3", 2023, "CD67890", 75, 380000, 1500);






            List<ISellable> forSale = new List<ISellable> { fc, ec };
            House h = new House("Strandvejen 42, 2900 Hellerup", 1965, 4200000, "1234-AB");



            forSale.Add(h);

            foreach (ISellable s in forSale)
            {
                Console.WriteLine(s.GetSalesSummary());
            }
            // Beregn samlet salgspris 
            double total = 0;
            foreach (ISellable s in forSale)
                total += s.Price;
            Console.WriteLine($"Samlet beholdningsværdi: {total:N0} kr");


            /////////////////
            ///Insurance
            ///

            List<IInsurable> insured = new List<IInsurable> { fc, ec };
            insured.Add(h);

            double totalinsurance = 0;
            double totalinsurancerate = 0;
            foreach (IInsurable i in insured)
            {
                Console.WriteLine($"------ Nyt Object -----");
                Console.WriteLine($"{i.RegistrationNumber}: {i.GetInsuranceRate():F1}%");
                Console.WriteLine($"Insurance pris {i.Price*(i.GetInsuranceRate()/100):N0}");
                totalinsurance += i.Price * (i.GetInsuranceRate() / 100);
                totalinsurancerate += i.GetInsuranceRate();
            }
            Console.WriteLine($"------ Beregning -----");
            Console.WriteLine($"Insurance pris total {totalinsurance:N0}");
            Console.WriteLine($"Insurance rate gennemsnit {totalinsurancerate/insured.Count():N0}%");
        */

        }
    }
}
