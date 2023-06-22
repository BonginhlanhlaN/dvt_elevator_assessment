using elevator.console.Implementations;
using elevator.console.Interfaces;
using System;
using System.Collections.Generic;

namespace elevator.console
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many elevators does your building have?: ");

            string numberOfElevators = Console.ReadLine();

            IBuilding building = new Building();

            List<IElevator> buildingElevatores = building.CreateElevators(int.Parse(numberOfElevators));

            building.Elevators = buildingElevatores;

            Console.WriteLine("Which Floor are you on ?: ");
            string passagerFloor = Console.ReadLine();

            Console.WriteLine("Which Floor are you going to ?: ");
            string passagerDestination = Console.ReadLine();

            IPassanger passager = new Passager()
            {
                FromFloor = int.Parse(passagerFloor),
                ToFloor = int.Parse(passagerDestination),
            };

            IElevator closestElevator = building.ChooseNearestElevator(passager);

            closestElevator.Move(passager);
            closestElevator.OnLoad(passager);

            building.UpdateElevatorAfterMove(closestElevator);

        }
    }
}
