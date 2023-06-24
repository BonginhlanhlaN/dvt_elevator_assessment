using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.console.Interfaces
{
    public interface IElevatorSummonRequest : IElevatorRequest
    {

        public int SummonedFloor { get; set; }

    }
}
