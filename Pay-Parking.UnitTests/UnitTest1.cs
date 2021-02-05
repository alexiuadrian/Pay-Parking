using System;
using System.Diagnostics.CodeAnalysis;
using Pay_Parking.Classes;
using Xunit;

namespace Pay_Parking.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void ShowCars_NoCars_ReturnsFalse()
        {
            var parking = new Parking();

            var result = parking.ShowCars();
            
            Assert.False(result);
        }

        [Fact]
        public void ShowCars_OneCar_ReturnsTrue()
        {
            var parking = new Parking();
            var car = new Car("TEST");
            parking.Cars.Add(car);
            
            var result = parking.ShowCars();

            Assert.True(result);
        }


        [Fact]
        public void AddCar_NoFreeSpots_ReturnsFalse()
        {
            var parking = new Parking();
            Parking.ParkingSpots = 0;
            var car = new Car("TEST");

            var result = parking.AddCar(car.LicensePlate);
            
            Assert.False(result);
        }

        [Fact]
        public void AddCar_SameLicensePlate_ReturnsFalse()
        {
            var parking = new Parking();
            var car1 = new Car("TEST");
            var car2 = new Car("TEST");

            parking.AddCar(car1.LicensePlate);
            var result = parking.AddCar(car2.LicensePlate);

            Assert.False(result);
        }

        [Fact]
        public void AddCar_OneCarWithEnoughSpace_ReturnsTrue()
        {
            var parking = new Parking();
            var car = new Car("TEST");
            
            var result = parking.AddCar(car.LicensePlate);

            Assert.True(result);
        }

        [Fact]
        public void FreeSpot_NoCarFound_ReturnsFalse()
        {
            var parking = new Parking();
            var car = new Car("TEST");
            
            var result = parking.FreeSpot(car.LicensePlate);

            Assert.False(result);
        }

        [Fact]
        public void FreeSpot_OneExistingCar_ReturnsTrue()
        {
            var parking = new Parking();
            var car = new Car("TEST");
            
            parking.AddCar(car.LicensePlate);
            
            var result = parking.FreeSpot(car.LicensePlate);

            Assert.True(result);
        }

        [Fact]
        public void ShowSummary_PriceBetweenTwoHours_ReturnsTrue()
        {
            var summary = new Summary(new Car("TEST"));
            
            // Intre 05.02.2021 19:24:00 si 05.02.2021 21:40:00 sunt 136 de minute = 2h 16 min
            // Masina ar trebui tarifata pentru 3h in cazul de mai sus, adica cu 10 + (3 - 1) * 5 = 20
            // 10 lei reprezinta prima ora, (3 - 1) numarul de ore pe langa prima ora inmultit cu 5 lei/h

            summary.StartDate = DateTime.Parse("05.02.2021 19:24:00");
            summary.EndDate = DateTime.Parse("05.02.2021 21:40:00");

            var result = summary.ShowSummary();
            
            Assert.Equal(20, result);
        }
    }
}
