﻿using System;
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
            Action exitAction = Substitute.For<Action>();
            string command = "Luis";
            console.Read().Returns(command);
            Ohce ohce = new Ohce(time, console, exitAction);            

            //Act
            ohce.Greet();

            //Assert
            console.Received().Print("¡Buenas tardes Luis!");
        }
        
        [Fact]
        public void Ohce_Should_Return_Buenos_Dias_And_Name_When_Current_Time_Is_Between_6_And_12()
        {
            //Arrange
            ITime time = new MorningTime();
            IConsole console = Substitute.For<IConsole>();
            Action exitAction = Substitute.For<Action>();
            string command = "Luis";
            console.Read().Returns(command);
            Ohce ohce = new Ohce(time, console, exitAction);

            //Act
            ohce.Greet();

            //Assert
            console.Received().Print("¡Buenas días Luis!");
        }

        [Fact]
        public void Ohce_Should_Return_Buenos_Noches_And_Name_When_Current_Time_Is_Between_20_And_6()
        {
            //Arrange
            ITime time = new NightTime();
            IConsole console = Substitute.For<IConsole>();
            Action exitAction = Substitute.For<Action>();
            string command = "Luis";
            console.Read().Returns(command);
            Ohce ohce = new Ohce(time, console, exitAction);

            //Act
            ohce.Greet();

            //Assert
            console.Received().Print("¡Buenas noches Luis!");
        }

        [Fact]
        public void Should_Return_Reversed_Input()
        {
            ITime time = new NightTime();
            IConsole console = Substitute.For<IConsole>();
            Action exitAction = Substitute.For<Action>();
            string command = "hola";
            console.Read().Returns(command);
            Ohce ohce = new Ohce(time, console, exitAction);

            ohce.Execute();

            console.Received().Print("aloh");
        }

        //5- Ohce should return reverse input and ¡Bonita palabra! When is Palindrome
        [Fact]
        public void Should_Return_Reversed_Input_When_is_Palindrome()
        {
            ITime time = new NightTime();
            IConsole console = Substitute.For<IConsole>();
            Action exitAction = Substitute.For<Action>();
            string command = "oto";
            console.Read().Returns(command);
            Ohce ohce = new Ohce(time, console, exitAction);

            ohce.Execute();

            console.Received().Print("oto");
            console.Received().Print("¡Bonita palabra!");
        }
         
        [Fact]
        public void Should_Return_Adios_And_Name_When_Input_is_Stop()
        {
            ITime time = new NightTime();
            IConsole console = Substitute.For<IConsole>();
            string name = "Luis";
            Action exitAction = Substitute.For<Action>();
            string command = "Stop!";
            console.Read().Returns(command);
            Ohce ohce = new Ohce(time, console, exitAction) { Name = name };

            ohce.Execute();

            console.Received().Print("Adios Luis");
            Assert.Equal(exitAction.ReceivedCalls().Count(), 1);
        }

        [Fact]
        public void Ohce_Should_PrintOnlyOnce_When_Current_Time_Is_Between_20_And_6()
        {
            ITime time = new NightTime();
            IConsole console = Substitute.For<IConsole>();
            Action exitAction = Substitute.For<Action>();
            string command = "Luis";
            console.Read().Returns(command);
            Ohce ohce = new Ohce(time, console, exitAction);

            ohce.Greet();

            console.Received(1).Print(Arg.Any<string>());
        }

        [Fact]
        public void Ohce_Should_PrintOnlyOnce_When_Current_Time_Is_Between_6_And_12()
        {
            ITime time = new MorningTime();
            IConsole console = Substitute.For<IConsole>();
            Action exitAction = Substitute.For<Action>();
            string command = "Luis";
            console.Read().Returns(command);
            Ohce ohce = new Ohce(time, console, exitAction);

            ohce.Greet();

            console.Received(1).Print(Arg.Any<string>());
        }

        [Fact]
        public void Ohce_Should_PrintOnlyOnce_When_Current_Time_Is_Between_12_And_20()
        {
            ITime time = new AfternoonTime();
            IConsole console = Substitute.For<IConsole>();
            Action exitAction = Substitute.For<Action>();
            string command = "Luis";
            console.Read().Returns(command);
            Ohce ohce = new Ohce(time, console, exitAction);

            ohce.Greet();

            console.Received(1).Print(Arg.Any<string>());
        }
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
