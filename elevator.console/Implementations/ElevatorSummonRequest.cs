using elevator.console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.console.Implementations
{
    public class ElevatorSummonRequest : IElevatorSummonRequest
    {

        public int SummonedFloor { get; set; }

    }
}
