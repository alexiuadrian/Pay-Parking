using System;
using System.Collections.Generic;
using System.Linq;

namespace Pay_Parking.Classes
{
    public class Parking
    {
        public static int ParkingSpots { get; set; }
        public List<Car> Cars { get; set; }

        public List<Summary> Summaries { get; set; }

        public Parking()
        {
            ParkingSpots = 10;
            Cars = new List<Car>();
            Summaries = new List<Summary>();
        }

        public void ShowCars()
        {
            Console.WriteLine("\n");
            foreach (var car in Cars)
            {
                Console.WriteLine(car.LicensePlate);
            }
        }

        public void AddCar()
        {
            if (ParkingSpots == 0)
            {
                Console.WriteLine("\nNu mai sunt locuri libere in parcare! Va rugam asteptati pana ce se elibereaza un loc.");
                return;
            }
                
            Console.Write("\nNumarul de inmatriculare al masinii: ");
            string licensePlate = Console.ReadLine();

            // Variabila pentru a verifica daca mai exista o masina cu acest numar de inmatriculare in parcare
            var checkCar = Cars.SingleOrDefault(c => c.LicensePlate.Equals(licensePlate)); 

            // Daca mai exista, afisam un mesaj utilizatorului si iesim din functie
            if (checkCar != null)
            {
                Console.WriteLine("Ati introdus un numar de inmatriculare gresit! Exista deja o masina cu acest numar in parcare!");
                return;
            }

            Car car = new Car(licensePlate);
            Cars.Add(car);

            Summary summary = new Summary(car);

            Summaries.Add(summary);
        }

        public void FreeSpot()
        {
            Console.Write("\nNumarul de inmatriculare al masinii: ");
            string licensePlate = Console.ReadLine();
            
            Car car;
            try
            {
                car = Cars.SingleOrDefault(c => c.LicensePlate.Equals(licensePlate));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            // Verificam daca exista masina pe care dorim sa o stergem
            if (car == null)
            {
                Console.WriteLine("Ati introdus un numar de inmatriculare gresit! Masina nu se afla in aceasta parcare!");
                return;
            }

            Cars.Remove(car);

            try
            {
                var summary = Summaries.SingleOrDefault(s => s.Car.LicensePlate == licensePlate);
                
                summary.EndDate = DateTime.Now;
                
                // Expresie de test pentru mai multe ore
                // summary.EndDate = DateTime.Now.AddHours(1).AddMinutes(10); 
                summary.ShowSummary();

                Summaries.Remove(summary);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void UpdateParkingSpots()
        {
            ParkingSpots = 10 - Cars.Count;
        }
    }
}