using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarAppNew;
using System;
using System.Collections.Generic;

namespace CarAppTests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
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

        [TestMethod]
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
    }
}
