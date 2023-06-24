using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.console.Interfaces
{
    public interface IElevatorDestinationRequest : IElevatorRequest
    {

        public int DestinationFloor { get; set; }

    }
}
