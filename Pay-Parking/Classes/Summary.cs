using System;

namespace Pay_Parking.Classes
{
    public class Summary
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ParkTime { get; set; }
        public Car Car { get; set; }

        public Summary(Car car)
        {
            Car = car;
            StartDate = DateTime.Now;
        }
        
        public void DoPrice()
        {
            this.ParkTime = (int) Math.Ceiling((EndDate - StartDate).TotalHours);
        }

        public void ShowSummary()
        {
            DoPrice();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Pentru masina cu numarul de inmatriculare: " + Car.LicensePlate);
            Console.WriteLine("Ati parcat la: " + StartDate);
            Console.WriteLine("Ati eliberat parcarea la: " + EndDate);
            Console.WriteLine("Timpul de stationare: " + ParkTime + "h");
            if (ParkTime == 1)
            {
                Console.WriteLine("Costul parcarii este 10 Lei");
            }
            else
            {
                // Pretul final este calculat in functie de numarul orelor stationate (in afara de prima) inmultit cu 5 la care se adauga pretul
                // primei ore
                int price = (ParkTime - 1) * 5 + 10;
                Console.WriteLine("Costul parcarii este " + price + " Lei");
            }
            Console.WriteLine("-----------------------------------");
        }
    }
}