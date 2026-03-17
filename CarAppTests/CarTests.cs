using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarAppNew;
using System;
using System.Collections.Generic;

namespace CarAppTests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod] //Tester om GetTripsByDate returnerer det rette antal ture for en given dato
        public void GetTripsByDate_ReturnsMatchingTrips()
        {
            // Arrange
            Car car = new Car("Toyota", "Corolla", 2020, "AB12345", FuelType.Benzin, 22.5);
            car.TurnOnEngine();

            DateTime today = new DateTime(2024, 6, 1, 10, 0, 0);

            Trip trip1 = new Trip(car, 50, today, today.AddHours(1));
            Trip trip2 = new Trip(car, 30, today, today.AddMinutes(45));
            Trip trip3 = new Trip(car, 20, today.AddDays(1), today.AddDays(1).AddHours(1));

            car.Drive(trip1);
            car.Drive(trip2);
            car.Drive(trip3);

            // Act
            List<Trip> result = car.GetTripsByDate(today);

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod] //Tester om GetTripsByDate returnerer en tom liste, når der ikke er nogen ture for den angivne dato
        public void GetTripsByDate_ReturnsEmptyList()
        {
            // Arrange
            Car car = new Car("Toyota", "Corolla", 2020, "AB12345", FuelType.Benzin, 22.5);
            car.TurnOnEngine();

            DateTime date = new DateTime(2024, 6, 1);

            Trip trip1 = new Trip(car, 50, new DateTime(2024, 6, 2), new DateTime(2024, 6, 2).AddHours(1));

            car.Drive(trip1);

            // Act
            List<Trip> result = car.GetTripsByDate(date);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod] //Tester om GetTripsInTimeInterval returnerer det rette antal ture inden for det angivne tidsinterval
        public void GetTripsInTimeInterval_ReturnsTripsWithinInterval()
        {
            // Arrange
            Car car = new Car("Toyota", "Corolla", 2020, "AB12345", FuelType.Benzin, 22.5);
            car.TurnOnEngine();

            DateTime start = new DateTime(2024, 6, 1, 8, 0, 0);
            DateTime end = new DateTime(2024, 6, 1, 16, 0, 0);

            Trip trip1 = new Trip(car, 50, new DateTime(2024, 6, 1, 9, 0, 0), new DateTime(2024, 6, 1, 10, 0, 0));
            Trip trip2 = new Trip(car, 30, new DateTime(2024, 6, 1, 14, 0, 0), new DateTime(2024, 6, 1, 15, 0, 0));
            Trip trip3 = new Trip(car, 20, new DateTime(2024, 6, 1, 18, 0, 0), new DateTime(2024, 6, 1, 19, 0, 0));

            car.Drive(trip1);
            car.Drive(trip2);
            car.Drive(trip3);

            // Act
            List<Trip> result = car.GetTripsInTimeInterval(start, end);

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod] //Tester om GetTripsInTimeInterval inkluderer ture, der starter eller slutter præcis på grænsetidspunkterne for intervallet
        public void GetTripsInTimeInterval_IncludesBoundaryTrips()
        {
            // Arrange
            Car car = new Car("Toyota", "Corolla", 2020, "AB12345", FuelType.Benzin, 22.5);
            car.TurnOnEngine();

            DateTime start = new DateTime(2024, 6, 1, 8, 0, 0);
            DateTime end = new DateTime(2024, 6, 1, 16, 0, 0);

            Trip trip1 = new Trip(car, 20, start, start.AddHours(1)); // start boundary
            Trip trip2 = new Trip(car, 30, end, end.AddHours(1));     // end boundary

            car.Drive(trip1);
            car.Drive(trip2);

            // Act
            List<Trip> result = car.GetTripsInTimeInterval(start, end);

            // Assert
            Assert.AreEqual(2, result.Count);
        }
    }
}
