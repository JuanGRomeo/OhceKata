using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using NSubstitute;
using Xunit.Extensions;

namespace OhceKata
{
    public class OhceTest
    {
        [Fact]
        public void Should_Return_Buenos_Tardes_And_Name_When_Current_Time_Is_Between_12_And_20()
        {
            ITime time = new AfternoonTime();
            IConsole console = Substitute.For<IConsole>();
            string command = "Luis";
            console.Read().Returns(command, "Stop!");
            Ohce ohce = new Ohce(time, console);
            
            ohce.Run();
            
            console.Received().Print("¡Buenas tardes Luis!");
        }

        [Fact]
        public void Ohce_Should_Return_Buenos_Dias_And_Name_When_Current_Time_Is_Between_6_And_12()
        {
            ITime time = new MorningTime();
            IConsole console = Substitute.For<IConsole>();
            string command = "Ohce Luis";
            console.Read().Returns(command, "Stop!");
            Ohce ohce = new Ohce(time, console);

            ohce.Run();

            console.Received().Print("¡Buenos días Luis!");
        }

        [Fact]
        public void Ohce_Should_Return_Buenos_Noches_And_Name_When_Current_Time_Is_Between_20_And_6()
        {
            ITime time = new NightTime();
            IConsole console = Substitute.For<IConsole>();
            string command = "Luis";
            console.Read().Returns(command, "Stop!");
            Ohce ohce = new Ohce(time, console);

            ohce.Run();

            console.Received().Print("¡Buenas noches Luis!");
        }

        [Fact]
        public void Should_Return_Reversed_Input()
        {
            ITime time = new NightTime();
            IConsole console = Substitute.For<IConsole>();
            string command = "hola";
            console.Read().Returns("ohce", command, "Stop!");
            Ohce ohce = new Ohce(time, console);

            ohce.Run();

            console.Received().Print("aloh");
        }

        [Fact]
        public void Should_Return_Reversed_Input_When_is_Palindrome()
        {
            ITime time = new NightTime();
            IConsole console = Substitute.For<IConsole>();
            console.Read().Returns("ohce Juan", "oto", "Stop!");
            Ohce ohce = new Ohce(time, console);

            ohce.Run();

            console.Received().Print("oto");
            console.Received().Print("¡Bonita palabra!");
        }

        [Fact]
        public void Should_Return_Adios_And_Name_When_Input_is_Stop()
        {
            ITime time = new NightTime();
            IConsole console = Substitute.For<IConsole>();
            console.Read().Returns("Juan", "Stop!");
            Ohce ohce = new Ohce(time, console);

            ohce.Run();

            console.Received().Print("Adios Juan");
        }

        [Fact]
        public void Should_Process_All_Commands()
        {
            ITime time = new NightTime();
            IConsole console = Substitute.For<IConsole>();
            console.Read().Returns("Juan", "hola", "camion", "Stop!");
            Ohce ohce = new Ohce(time, console);

            ohce.Run();

            console.Received().Print("noimac");
        }

        [Theory, MemberData(nameof(getTimeGreetings))]
        public void Ohce_Should_Greet_Only_Once_At_AnyTime(ITime time, string greet)
        {
            IConsole console = Substitute.For<IConsole>();
            string command = "Ohce Luis";
            console.Read().Returns(command, "Stop!");
            Ohce ohce = new Ohce(time, console);

            ohce.Run();

            console.Received(2).Print(Arg.Any<string>());
        }

        [Theory, MemberData(nameof(getTimeGreetings))]
        public void Ohce_Should_Greet_Ignoring_keyword_Ohce(ITime time, string greet)
        {
            IConsole console = Substitute.For<IConsole>();
            console.Read().Returns("Ohce Luis", "Stop!");
            Ohce ohce = new Ohce(time, console);             

            ohce.Run();

            console.Received().Print(greet);
        }

        public static IEnumerable<object[]> getTimeGreetings
        {
            get
            {
                return new[]
                {
                    new object[] { new MorningTime(), "¡Buenos días Luis!" },
                    new object[] { new AfternoonTime(), "¡Buenas tardes Luis!" },
                    new object[] { new NightTime(), "¡Buenas noches Luis!" }
                };
            }
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
