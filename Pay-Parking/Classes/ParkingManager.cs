using System;
using System.Threading;

namespace Pay_Parking.Classes
{
    public class ParkingManager
    {
        public Parking Parking { get; set; }
        
        public ParkingManager()
        {
            Parking = new Parking();
        }

        // Meniul afisat utilizatorului
        public int Menu()
        {
            int option = 0; // Utilizatorul va trebui sa furnizeze o optiune din meniu
            
            Console.WriteLine("\n");
            Console.WriteLine("Numarul de locuri disponibile in parcare: " + Parking.ParkingSpots);
            Console.WriteLine("\n");
            Console.WriteLine("Alegeti o optiune:");
            Console.WriteLine("1. Afisati lista de masini parcate");
            Console.WriteLine("2. Parcati masina");
            Console.WriteLine("3. Eliberati locul");
            Console.WriteLine("4. Iesiti");
            Console.WriteLine("\n");
            
            try
            {
                Console.Write("Optiunea dumneavoastra: ");
                option = Int32.Parse(Console.ReadLine());

                if (option > 4 || option < 1)
                {
                    Console.WriteLine("\nVa rugam sa introduceti o optiune valida.");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("\nVa rugam sa introduceti o optiune valida.");
                // throw;
            }

            return option;
        }

        public void ManageOption(int option)
        {
            switch (option)
            {
                case 1:
                {
                        Parking.ShowCars();
                        break;
                }
                case 2:
                {
                    Parking.AddCar();
                    Parking.UpdateParkingSpots();
                    break;
                }
                case 3:
                {
                    Parking.FreeSpot();
                    Parking.UpdateParkingSpots();
                        break;
                }
                case 4:
                {
                    return;
                }
                default:
                {
                    break;
                }
            }
        }
    }
}