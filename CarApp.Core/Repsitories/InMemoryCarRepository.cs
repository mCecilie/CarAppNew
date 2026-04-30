using CarApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace CarApp.Core.Repositories
{

    public class InMemoryCarRepository : ICarRepository
    {
        private readonly List<Car> _cars = new List<Car>();
        public void Add(Car car)
        {

            // LINQ version - den er meget bedre, Any metoden er dope!
            string licenseplate = car.LicensePlate;
            Console.WriteLine(licenseplate);
            if (_cars.Any(c => c.LicensePlate == licenseplate))
            {
                Console.WriteLine("Bil allerede registreret");
            }
            else
            {
                Console.WriteLine("Car added");
                _cars.Add(car);
            }
            /* DERES LINQ
            var existingCar = _cars.FirstOrDefault(c => c.LicensePlate == car.LicensePlate);
            if (existingCar == null)
            {
                _cars.Add(car);
                Console.WriteLine("Car tilføjet");
            }
            */

            /* V1 -- list version
            bool carExists = false;
            string licenseplate = car.LicensePlate;
            Console.WriteLine(licenseplate);

            foreach (var carinlist in _cars)
            {
                if (carinlist.LicensePlate == licenseplate)
                {
                    Console.WriteLine("Bil allerede registreret");
                    carExists = true;
                    break;
                }
            }
            if (!carExists)
            {
                _cars.Add(car);
                Console.WriteLine("Car tilføjet");
            }
            */


        }
        
        public void Delete(string licenseplate)
        {
            _cars.RemoveAll(c => c.LicensePlate == licenseplate);
        }

        public IEnumerable<Car> GetAll()
        {
            return _cars;
        }

        public Car GetByLicensePlate(string licenseplate)
        {
            return _cars.FirstOrDefault(c => c.LicensePlate == licenseplate);
        }
        
        public void Update(Car car)
        {

            var existingCar = _cars.FirstOrDefault(c => c.LicensePlate == car.LicensePlate);
            if (existingCar != null)
            {
               // existingCar.Model = car.Model;
                //existingCar.LicensePlate = car.LicensePlate;
            }
        }
    }
}
