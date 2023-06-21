using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.console.Interfaces
{
    public interface IPassanger
    {

        public int FromFloor { get; set; }
        public int ToFloor { get; set; }

    }
}
