using System;

namespace OhceKata
{
    public class Ohce
    {
        private Time time;

        public Ohce(Time time)
        {
            this.time = time;
        }

        public string Name { get; set; }

        public string Execute(string input)
        {
            throw new NotImplementedException();
        }

        internal string Greeting(string name)
        {
            if (time.currentTime().Hour >= 6 && time.currentTime().Hour < 12)
                return "¡Buenas días " + name + "!";

            return "¡Buenas tardes " + name + "!";
        }
    }
}