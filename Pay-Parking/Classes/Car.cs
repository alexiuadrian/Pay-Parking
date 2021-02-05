namespace Pay_Parking.Classes
{
    public class Car
    {
        public string LicensePlate { get; set; }

        public Car()
        {

        }

        public Car(string licensePlate)
        {
            this.LicensePlate = licensePlate;
        }
    }
}