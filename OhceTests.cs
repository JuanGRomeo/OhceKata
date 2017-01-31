using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace OhceKata
{
    public class OhceTest
    {

        //1- Ohce should return Buenos Tardes and name When current time is between 12 and 20
        [Fact]
        public void Should_Return_Buenos_Tardes_And_Name_When_Current_Time_Is_Between_12_And_20()
        {
            //Arrange
            Time time = new AfternoonTime();
            Ohce ohce = new Ohce(time);

            //Act
            string greeting = ohce.Greeting("Luis");

            //Assert
            Assert.Equal("¡Buenas tardes Luis!", greeting);
        }

        //2- Ohce should return Buenos Dias and name When current time is between 6 and 12

        //3- Ohce should return Buenos Noches and name When current time is between 20 and 6

        //4- Ohce should return reverse input 

        //5- Ohce should return reverse input and ¡Bonita palabra! When is Palindrome

        //6- Ohce should return Adios + name When input is Stop! 
    }

    internal class AfternoonTime : Time
    {
        public DateTime currentTime()
        {
            return new DateTime(2017, 01, 31, 18, 00, 00);
        }
    }
}
