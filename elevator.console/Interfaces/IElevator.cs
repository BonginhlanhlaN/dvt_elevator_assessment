using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.console.Interfaces
{
    public interface IElevator
    {

        public List<IPassanger> Passagers { get; set; }
        public int CurrentFloor { get; set; }
        public int ToFloor { get; set; }
        public int Direction { get; set; }

        public Task Move();

        public void OnLoad();
        public void OfLoad();

    }
}
