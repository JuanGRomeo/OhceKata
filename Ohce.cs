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
            return "¡Buenas tardes " + name + "!";
        }
    }
}