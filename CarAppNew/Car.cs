namespace CarAppNew
{
    public class Car
    {
        //Opretter mine variabler og properties for Car klassen.
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string LicensePlate { get; private set; }
        public FuelType FuelType { get; private set; }
        public double KmPerLiter { get; private set; }
        public double Odometer { get; private set; }

        // Opretter en privat liste af Trip objekter, som vil holde styr på alle ture foretaget med bilen.
        private List<Trip> _trips = new List<Trip>();
        private Engine _engine;

        //Opretter en kontruktør for Car klassen, som tager alle nødvendige parametre for at initialisere en bil.
        public Car(string brand, string model, int year,
        string licensePlate, FuelType fuelType, double kmPerLiter)
        {
            Brand = brand;
            Model = model;
            Year = year;
            LicensePlate = licensePlate;
            FuelType = fuelType;
            KmPerLiter = kmPerLiter;
            _engine = new Engine();
        }

        //Tjekker om bilen er tændt eller slukket ved at kalde på Engine klassen.
        public void TurnOnEngine() => _engine.Start();
        public void TurnOffEngine() => _engine.Stop();

        //metode til at registrere en ny køretur for bilen.
        //Den tager et Trip objekt som parameter og opdaterer bilens odometer og tilføjer til liste over køreture.
        public void Drive(Trip newTrip)
        {
            if (newTrip.Car == this)
            {
                Odometer += newTrip.Distance;
                _trips.Add(newTrip);
            }

            else
            {
                Console.WriteLine("Fejl: Denne tur tilhører ikke denne bil.");
            }
        }

        //Metode til at hente alle ture foretaget med bilen.
        public List<Trip> GetTrips() => _trips;

    }
}
