using OhceKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhceProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            MyTime time = new MyTime();
            MyConsole console = new MyConsole();
            Action exitAction = () => { run = false; };
            Ohce ohce = new Ohce(time, console, exitAction);

            ohce.Run();
        }
    }
}
