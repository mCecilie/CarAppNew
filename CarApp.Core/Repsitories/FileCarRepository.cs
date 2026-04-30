using CarApp.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace CarApp.Core.Repositories
{
    public class FileCarRepository : ICarRepository
    {
        private readonly string FilePath;


        public FileCarRepository(string filePath)

        {

            FilePath = filePath;
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

        }


        public IEnumerable<Car> GetAll()

        {            
            // Læs alle linjer med StreamReader

            // For hver linje: split paa komma, tjek type (parts[0])

            // Kald FuelCar.FromString() eller ElectricCar.FromString()
            List<Car> cars = new List<Car>();
            try
            {
                using (StreamReader reader = new StreamReader(FilePath))

                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        string carType = parts[0]; // få cartype fra den første del af csv (første komma)

                        Car car = null; // temporary car for at indholde cartype
                        if (carType == "FuelCar")
                        {
                            car = FuelCar.FromString(line);
                        }
                        else if (carType == "ElectricCar")
                        {
                            car = ElectricCar.FromString(line);
                        }
                        if (car != null)
                        {
                            cars.Add(car);

                        }
                    }
                }
            }

            catch (IOException ex)
            {
                Console.WriteLine($"Fejl ved læsning af fil: {ex.Message}");
                return new List<Car>();
            }
            return cars;


        }


        public Car GetByLicensePlate(string licensePlate)

        {
            // Brug GetAll() og find bilen med den givne nummerplade
            IEnumerable<Car> cars = GetAll();
            return cars.FirstOrDefault(c => c.LicensePlate == licensePlate);


        }


        public void Add(Car car)

        {
            // Skriv car.ToString() som en ny linje med StreamWriter (append)
            File.AppendAllText(FilePath, car.ToString() + "\n");


        }


        public void Update(Car car)

        {
            List<Car> cars = GetAll().ToList();
            int index = cars.FindIndex(c => c.LicensePlate == car.LicensePlate); //index er e.g Cars[0] som er den første bil osv.
            if (index != -1) 
            {
                cars[index] = car;
                Console.WriteLine("updated car");
                RewriteFile(cars);

            }

        }

        public void RewriteFile(List<Car> cars) // added den her, men vi kan bare lige den ind i delete i teorien
        {
            try
            {
                File.WriteAllLines(FilePath, cars.Select(c => c.ToString()));
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Fejl ved skrivning til fil: {ex.Message}");
            }
        }

        public void Delete(string licensePlate)

        {
            Console.WriteLine("Slet alle med nummerplade? Y/N/B back");
            string input = Console.ReadLine().ToLower();
            List<Car> cars = GetAll().ToList(); // lav det om til en liste så vi kan slette fra enum


            if (input == "y")
            {
                cars.RemoveAll(c => c.LicensePlate == licensePlate);
            }
            // læs licenseplate
            else if (input == "n")
            {
                List<Car> carsWithLicensePlate = cars.Where(c => c.LicensePlate != licensePlate).ToList();
                Car carToDelete = cars.First();
                cars.Remove(carToDelete);
            }

            RewriteFile(cars);
        }
    }
}

/// old delete
/// public void Delete(string licensePlate)
/*
try
{
Console.WriteLine("Slet alle med nummerplade? Y/N/B back");
string input = Console.ReadLine().ToLower();
IEnumerable<Car> cars = GetAll();
IEnumerable<Car> carsWithoutLicensePlate = cars.Where(c => c.LicensePlate != licensePlate); // find alle biler der IKKE har nummerpladen. Det skriver vi til en liste
if (carsWithoutLicensePlate != null) // tjek om der er nogle i listen
{

if (input == "y")
{
using (StreamWriter writer = new StreamWriter(FilePath))
{
    foreach (var car in carsWithoutLicensePlate)
    {
        writer.WriteLine(car.ToString()); //Vi skriver biler UDEN nummerpladen på
        Console.WriteLine($"{car.ToString()} Er den eneste tilbage");
    }
}

}
else if (input == "n")
{
Car carToDelete = carsWithoutLicensePlate.First(); //find den første af dem der ikke har den rigtige nummerplade
using (StreamWriter writer = new StreamWriter(FilePath))
{
    writer.WriteLine(carToDelete.ToString());
    Console.WriteLine($"{carToDelete.ToString()} slettet");
}
}
else
{
Console.WriteLine("Bil ikke fundet");
}
}

catch (IOException ex)
{
Console.WriteLine($"Fejl ved sletning af bil: {ex.Message}");
}}*/


