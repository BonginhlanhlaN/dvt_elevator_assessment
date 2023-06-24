using elevator.console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.console.Implementations
{
    class ElevatorDestinationRequest : IElevatorDestinationRequest
    {

        public int DestinationFloor { get; set; }

    }
}
