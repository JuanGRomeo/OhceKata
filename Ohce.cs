using System;

namespace OhceKata
{
    public class Ohce
    {
        private ITime time;
        private IConsole console;

        public Ohce(ITime time, IConsole console)
        {
            this.time = time;
            this.console = console; 
        }

        public string Name { get; set; }

        public string Execute(string input)
        {
            throw new NotImplementedException();
        }

        internal void Greeting(string name)
        {
            if (time.currentTime().Hour >= 6 && time.currentTime().Hour < 12)
                console.Print("¡Buenas días " + name + "!");

            if (time.currentTime().Hour >= 20 || time.currentTime().Hour < 6)
                console.Print("¡Buenas noches " + name + "!");
            
            console.Print("¡Buenas tardes " + name + "!");
        }
    }
}