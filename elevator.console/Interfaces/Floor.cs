using elevator.console.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.console.Interfaces
{
    public class Floor : IFloor
    {
        public int FloorNum { get; set; }
        public List<IPassanger> PassagersWaiting { get; set; } 

    }
}
