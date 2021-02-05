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

        // Functia returneaza true in cazul in care se afla masini in parcare, false altfel
        public bool ShowCars()
        {
            Console.WriteLine("\n");
            if (Cars.Count == 0)
            {
                Console.WriteLine("Nu sunt masini in parcare!");
                return false;
            }
            Console.WriteLine("Masinile aflate in parcare: ");
            foreach (var car in Cars)
            {
                Console.WriteLine(" - " + car.LicensePlate);
            }

            return true;
        }

        // Functia returneaza true daca masina a fost adaugata in parcare, false altfel
        public bool AddCar(string licensePlate)
        {
            // Daca nu mai sunt locuri de parcare, afisam un mesaj si returnam false
            if (ParkingSpots == 0)
            {
                Console.WriteLine("\nNu mai sunt locuri libere in parcare! Va rugam asteptati pana ce se elibereaza un loc.");
                return false;
            }

            // Variabila pentru a verifica daca mai exista o masina cu acest numar de inmatriculare in parcare
            var checkCar = Cars.SingleOrDefault(c => c.LicensePlate.Equals(licensePlate)); 

            // Daca mai exista, afisam un mesaj utilizatorului si returnam false
            if (checkCar != null)
            {
                Console.WriteLine("Ati introdus un numar de inmatriculare gresit! Exista deja o masina cu acest numar in parcare!");
                return false;
            }

            Car car = new Car(licensePlate);
            Cars.Add(car);

            Summary summary = new Summary(car);

            Summaries.Add(summary);

            return true;
        }

        // Functia returneaza true daca a fost eliberat locul, false altfel
        public bool FreeSpot(string licensePlate)
        {

            Car car;
            try
            {
                car = Cars.SingleOrDefault(c => c.LicensePlate.Equals(licensePlate));
            }
            catch (Exception e)
            {
                Console.WriteLine("Au fost gasite mai multe masini cu acelasi numar de inmatriculare! Va rugam contactati administratorul.");
                return false;
            }
            
            // Verificam daca exista masina pe care dorim sa o stergem
            if (car == null)
            {
                Console.WriteLine("Ati introdus un numar de inmatriculare gresit! Masina nu se afla in aceasta parcare!");
                return false;
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
                Console.WriteLine("Nu s-a putut genera un sumar pentru masina dumneavoastra! Va rugam contactati administratorul.");
                return false;
            }

            return true;
        }

        public void UpdateParkingSpots()
        {
            ParkingSpots = 10 - Cars.Count;
        }
    }
}