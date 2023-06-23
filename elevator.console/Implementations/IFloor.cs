using elevator.console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.console.Implementations
{
    public interface IFloor
    {

        public int FloorNum { get; set; }
        public List<IPassanger> PassagersWaiting { get; set; }


    }
}
