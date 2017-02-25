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
        public void Should_Return_Reversed_Input()
        {
            ITime time = new NightTime();

            //IConsole console = Substitute.For<IConsole>();
            //string command = "hola";
            //console.Read().Returns("ohce", command, "Stop!");

            IConsole console = new ConsoleMockedBuilder()
                .AddCommand("Luis")
                .AddCommand("hola")
                .Build();

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
            ITime time = /**/new NightTime(); //Given a moment of Day
            IConsole console = Substitute.For<IConsole>();
            console.Read().Returns("Juan", "hola", "camion", "Stop!");
            Ohce ohce = new Ohce(time, console);

            ohce.Run();

            //console.Received().Print("aloh");
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
        public void Ohce_Should_Greet_Depending_On_Time(ITime time, string greet)
        {
            IConsole console = new ConsoleMockedBuilder()
                .AddCommand("Luis")
                .Build();            

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

    internal class ConsoleMockedBuilder
    {
        private IConsole console;
        private Queue<string> commands = new Queue<string>();

        public IConsole Build()
        {
            if (!commands.Contains("Stop!"))
                commands.Enqueue("Stop!");

            console = Substitute.For<IConsole>();
            console.Read().Returns(commands.Dequeue(), commands.ToArray());
            
            return console;
        }

        public ConsoleMockedBuilder AddCommand(string command)
        {
            if (commands.Count == 0)
            {
                command = "Ohce " + command;
            }

            commands.Enqueue(command);
            return this;
        }        
    }
}
