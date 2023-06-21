using elevator.console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.console.Implementations
{
    public class Passager  : IPassanger
    {

        public int FromFloor { get; set; }
        public int ToFloor { get; set; }

    }
}
