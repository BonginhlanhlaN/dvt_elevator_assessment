using elevator.console.Enums;
using elevator.console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.console.Implementations
{
    public class Building : IBuilding
    {

        public List<IElevator> Elevators { get; set; }
        public List<IFloor> Floors { get; set; }

        public List<IElevator> CreateElevators(int numberOfElevatorsInBuilding)
        {

            /**
                I did not want to assume the number of elevator
                I therefore allowed user input to determine the number of ELEVATORS in the "building".
             */

            List<IElevator> elevators = new();

            for (int i = 0; i < numberOfElevatorsInBuilding; i++)
            {

                IElevator elevator = new Elevator()
                {

                    Id = i,
                    CurrentFloor = 0,
                    ToFloor = 0,
                    Passagers = new List<IPassanger>(),
                    Direction = (int)ElevatorDirections.Idle

                };

                elevators.Add(elevator);

            }

            return elevators;

        }

        public List<IFloor> CreateFloors(int numberOfFloorsInBuilding)
        {

            /**
               I did not want to assume the number of FLOORS
               I therefore allowed user input to determine the number of floors in the "building".
            */

            List<IFloor> floors = new();

            for (int i = 0; i < numberOfFloorsInBuilding; i++)
            {

                IFloor elevator = new Floor()
                {

                    FloorNum = i,
                    PassagersWaiting = new List<IPassanger>(),
                  
                };

                floors.Add(elevator);

            }

            return floors;


        }

        public IElevator ChooseNearestElevator(IPassanger passanger)
        {

            /*
                I initially assume that the first elevator in the List<> is the closest.
                The foreach loop will prove me wrong or prove me right.
             */
            IElevator nearestElevator = this.Elevators[0];

            //This is to avoid negative floor distance numbers.
            int passangerElevatorFloorDistance = passanger.FromFloor >= this.Elevators[0].CurrentFloor ? passanger.FromFloor - this.Elevators[0].CurrentFloor : this.Elevators[0].CurrentFloor - passanger.FromFloor;

            foreach(IElevator elevator in this.Elevators)
            {

                //This is to avoid negative floor distance numbers.
                int currentPassangerElevatorFloorDistance = passanger.FromFloor >= elevator.CurrentFloor ? passanger.FromFloor - elevator.CurrentFloor : elevator.CurrentFloor - passanger.FromFloor;


                if (currentPassangerElevatorFloorDistance < passangerElevatorFloorDistance)
                {
                    nearestElevator = elevator;
                    passangerElevatorFloorDistance = currentPassangerElevatorFloorDistance;
                }

            }

            return nearestElevator;

        }

        public void UpdateElevatorAfterMove(IElevator elevator)
        {

            foreach (IElevator currentElevator in this.Elevators)
            {

                if (currentElevator.Id == elevator.Id)
                {

                    this.Elevators[currentElevator.Id] = elevator;
                    break;

                }

            }

        }

    }
}
