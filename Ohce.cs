using System;

namespace OhceKata
{
    public class Ohce
    {
        private ITime time;
        private IConsole console;
        private Action exitAction;

        public string Name { get; set; }

        public Ohce(ITime time, IConsole console)
        {
            this.time = time;
            this.console = console;
        }  

        public void Run()
        {
            Greet();

            bool run = true;
            exitAction = () => { run = false; };

            while (run)
            {
                Execute();
            }  
        }

        private void Greet()
        {
            Name = console.Read();

            if (time.currentTime().Hour >= 6 && time.currentTime().Hour < 12)
            {
                console.Print("¡Buenas días " + Name + "!");
                return;
            }

            if (time.currentTime().Hour >= 20 || time.currentTime().Hour < 6)
            {
                console.Print("¡Buenas noches " + Name + "!");
                return;
            }
            
            console.Print("¡Buenas tardes " + Name + "!");
        }

        private void Execute()
        {
            string input = console.Read();
            string reversedInput = string.Empty;

            if (input.Equals("Stop!"))
            {
                console.Print("Adios " + Name);
                exitAction();
                return;
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            reversedInput = new String(charArray);

            console.Print(reversedInput);

            if (reversedInput.Equals(input))
                console.Print("¡Bonita palabra!");
        }
    }
}