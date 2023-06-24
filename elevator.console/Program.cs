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

            IBuilding building = EnquireAboutBuilding();


            while (true)
            {

                try
                {

                    IElevator buildingElevator = ElevatorFun(building);

                    building.UpdateElevatorAfterMove(buildingElevator);

                }
                catch (Exception ex)
                {
                    break;
                }

            }

           
        }

        private static IBuilding EnquireAboutBuilding()
        {

            IBuilding building = new Building();

            try
            {
            
                Console.WriteLine("How many floors does your building have?: ");
                string numberOfFloors = Console.ReadLine();

                List<IFloor> buildingFloors = building.CreateFloors(int.Parse(numberOfFloors));
                building.Floors = buildingFloors;

                Console.WriteLine("How many elevators does your building have?: ");
                string numberOfElevators = Console.ReadLine();

                List<IElevator> buildingElevatores = building.CreateElevators(int.Parse(numberOfElevators));
                building.Elevators = buildingElevatores;

            }
            catch (System.FormatException ex)
            {
                EnquireAboutBuilding();
            }

            return building;
        }

        private static IElevator ElevatorFun(IBuilding building)
        {

            Console.WriteLine("Which Floor are you on?: ");
            string requestedFloor = Console.ReadLine();

            IElevatorSummonRequest elevatorSummonRequest = new ElevatorSummonRequest()
            {
                SummonedFloor = int.Parse(requestedFloor)
            };

            IElevator closestElevator = building.ChooseNearestElevator(elevatorSummonRequest);

            closestElevator.MoveToRequestedFloor(elevatorSummonRequest);

            closestElevator.DropOffPassagersToSummedFloor();

            Console.WriteLine("Which Floor are you going to?: ");
            string requestedDestination = Console.ReadLine();

            IElevatorDestinationRequest destinationRequest = new ElevatorDestinationRequest()
            {
                DestinationFloor = int.Parse(requestedDestination)
            };


            IPassanger passager = new Passager()
            {
                FromFloor = elevatorSummonRequest.SummonedFloor,
                ToFloor = destinationRequest.DestinationFloor
            };

            closestElevator.OnLoad(passager);


            closestElevator.MoveToDestinationFloor(destinationRequest);

            closestElevator.DropOffPassagersToDestination();

            return closestElevator;

        }
    }
}
