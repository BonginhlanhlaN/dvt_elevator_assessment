using elevator.console.Implementations;
using elevator.console.Interfaces;
using System;

namespace elevator.console
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many elevators does your build Have?:");

            // Create a string variable and get user input from the keyboard and store it in the variable
            string numberOfElevators = Console.ReadLine();

            IBuilding building = new Building();

            var createElevators = building.CreateElevators(int.Parse(numberOfElevators));

            building.Elevators = createElevators;

            var numberOfElavators = building.Elevators.Count;

            Console.WriteLine("Direction" + building.Elevators[0].Direction);
            Console.WriteLine("Current Floor" + building.Elevators[0].CurrentFloor);
           

        }
    }
}
