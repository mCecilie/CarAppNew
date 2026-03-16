using System;

namespace CarAppNew
{
    //Opretter nuy Engine klasse, som vil blive brugt i Car klassen til at håndtere motorens tilstand (tændt eller slukket).
    public class Engine
    {
        // Privat felt, som holder styr på om motoren er tændt eller slukket.
        private bool _isRunning;

        // Metode til at starte motoren. Den tjekker først om motoren allerede er tændt for at undgå unødvendige handlinger.
        public void Start()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                Console.WriteLine("Motoren er startet.");
            }
        }

        // Metode til at stoppe motoren. Den tjekker først om motoren allerede er slukket for at undgå unødvendige handlinger.
        public void Stop()
        {
            if (_isRunning)
            {
                _isRunning = false;
                Console.WriteLine("Motoren er stoppet.");
            }
        }
    }
}