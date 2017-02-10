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
            MyTime time = new MyTime();
            MyConsole console = new MyConsole();
            Ohce ohce = new Ohce(time, console);

            ohce.Run();
        }
    }
}
