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

        public void Run()
        {
            Greet();
            while (Execute()); 
        }

        private void Greet()
        {
            Name = console.Read().Replace("Ohce", "").Trim();

            if (time.currentTime().Hour >= 6 && time.currentTime().Hour < 12)
            {
                console.Print("¡Buenos días " + Name + "!");
                return;
            }

            if (time.currentTime().Hour >= 20 || time.currentTime().Hour < 6)
            {
                console.Print("¡Buenas noches " + Name + "!");
                return;
            }
            
            console.Print("¡Buenas tardes " + Name + "!");
        }

        private bool Execute()
        {
            string input = console.Read();
            string reversedInput = string.Empty;

            if (input.Equals("Stop!"))
            {
                console.Print("Adios " + Name);
                return false;
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            reversedInput = new String(charArray);

            console.Print(reversedInput);

            if (reversedInput.Equals(input))
                console.Print("¡Bonita palabra!");

            return true;
        }
    }
}