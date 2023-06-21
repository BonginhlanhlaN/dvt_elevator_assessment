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
        public int NumberOfFloors { get; set; }

        public List<IElevator> CreateElevators(int numberOfElevatorsInBuilding)
        {

            List<IElevator> elevators = new();

            for (int i = 0; i < numberOfElevatorsInBuilding; i++)
            {

                IElevator elevator = new Elevator()
                {

                    CurrentFloor = 0,
                    ToFloor = 0,
                    Passagers = new List<IPassanger>(),
                    Direction = (int)ElevatorDirections.Idle

                };

                elevators.Add(elevator);

            }

            return elevators;

        }

    }
}
