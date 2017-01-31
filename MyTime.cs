using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhceKata
{
    public class MyTime : ITime
    {
        public DateTime currentTime()
        {
            return DateTime.Now;
        }
    }
}
