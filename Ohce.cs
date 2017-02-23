using System;

namespace OhceKata
{
    public class Ohce
    {
        private ITime time;
        private IConsole console;

        public string Name { get; set; }        

        public Ohce(ITime time, IConsole console)
        {
            this.time = time;
            this.console = console;
        }

        public Ohce(): this(new MyTime(), new MyConsole())
        {
        }

        public void Run()
        {
            Greet();
            while (Execute()); 
        }

        private void Greet()
        {
            Name = console.Read().Replace("Ohce", "").Trim();

            console.Print("¡" + GetGreeting() + " " + Name + "!");
        }

        private string GetGreeting()
        {
            if (time.currentTime().Hour >= 6 && time.currentTime().Hour < 12)
            {
                return "Buenos días";                
            }

            if (time.currentTime().Hour >= 20 || time.currentTime().Hour < 6)
            {
                return "Buenas noches";
            }

            return "Buenas tardes";
        }

        private bool Execute()
        {
            string input = console.Read();

            if (input.Equals("Stop!"))
            {
                console.Print("Adios " + Name);
                return false;
            }

            string reversedInput = Reverse(input);

            console.Print(reversedInput);

            if (reversedInput.Equals(input))
                console.Print("¡Bonita palabra!");

            return true;
        }

        private static string Reverse(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new String(charArray);
        }
    }
}