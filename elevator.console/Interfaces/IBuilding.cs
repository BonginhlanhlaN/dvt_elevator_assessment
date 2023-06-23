using elevator.console.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.console.Interfaces
{
    public interface IBuilding
    {

        public List<IElevator> Elevators { get; set; }
        public List<IFloor> Floors { get; set; }


        public List<IElevator> CreateElevators(int numberOfElevatorsInBuilding);

        public List<IFloor> CreateFloors(int numberOfFloorsInBuilding);

        public IElevator ChooseNearestElevator(IPassanger passanger);

        public void UpdateElevatorAfterMove(IElevator elevator);

    }
}
