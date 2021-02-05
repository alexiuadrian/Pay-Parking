using System;
using Pay_Parking.Classes;

namespace Pay_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingManager parkingManager = new ParkingManager();
            int option = 0;
            while (option != 4)
            {
                option = parkingManager.Menu();
                parkingManager.ManageOption(option);
            }
        }
    }
}
