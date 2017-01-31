using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using NSubstitute;

namespace OhceKata
{
    public class OhceTest
    {
        [Fact]
        public void Should_Return_Buenos_Tardes_And_Name_When_Current_Time_Is_Between_12_And_20()
        {
            //Arrange
            ITime time = new AfternoonTime();
            IConsole console = Substitute.For<IConsole>();
            Ohce ohce = new Ohce(time, console);            

            //Act
            ohce.Greeting("Luis");

            //Assert
            console.Received().Print("¡Buenas tardes Luis!");
        }
        
        [Fact]
        public void Ohce_Should_Return_Buenos_Dias_And_Name_When_Current_Time_Is_Between_6_And_12()
        {
            //Arrange
            ITime time = new MorningTime();
            IConsole console = Substitute.For<IConsole>();
            Ohce ohce = new Ohce(time, console);

            //Act
            ohce.Greeting("Luis");

            //Assert
            console.Received().Print("¡Buenas días Luis!");
        }
        //3- Ohce should return Buenos Noches and name When current time is between 20 and 6
        [Fact]
        public void Ohce_Should_Return_Buenos_Noches_And_Name_When_Current_Time_Is_Between_20_And_6()
        {
            //Arrange
            ITime time = new NightTime();
            IConsole console = Substitute.For<IConsole>();
            Ohce ohce = new Ohce(time, console);

            //Act
            ohce.Greeting("Luis");

            //Assert
            console.Received().Print("¡Buenas noches Luis!");
        }

        //4- Ohce should return reverse input 

        //5- Ohce should return reverse input and ¡Bonita palabra! When is Palindrome

        //6- Ohce should return Adios + name When input is Stop! 
    }    

    internal class AfternoonTime : ITime
    {
        public DateTime currentTime()
        {
            return new DateTime(2017, 01, 31, 18, 00, 00);
        }
    }


    internal class MorningTime : ITime
    {
        public DateTime currentTime()
        {
            return new DateTime(2017, 01, 31, 9, 00, 00);
        }
    }

    internal class NightTime : ITime
    {
        public DateTime currentTime()
        {
            return new DateTime(2017, 01, 31, 21, 00, 00);
        }
    }
}
