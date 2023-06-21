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
        public int NumberOfFloors { get; set; }


        public List<IElevator> CreateElevators(int numberOfElevatorsInBuilding);

        public IElevator ChooseNearestElevator(IPassanger passanger);

    }
}
