using elevator.console.Implementations;
using elevator.console.Interfaces;
using System;

namespace elevator.console
{
    class Program
    {
        static void Main(string[] args)
        {

            IElevator elevatore = new Elevator();

            var awaiter = elevatore.Move().GetAwaiter();
            awaiter.GetResult();

        }
    }
}
