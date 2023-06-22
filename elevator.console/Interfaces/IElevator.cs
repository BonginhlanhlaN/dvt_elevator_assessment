using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.console.Interfaces
{
    public interface IElevator
    {

        public int Id { get; set; }
        public List<IPassanger> Passagers { get; set; }
        public int CurrentFloor { get; set; }
        public int ToFloor { get; set; }
        public int Direction { get; set; }

        public void Move(IPassanger passanger);

        public void OnLoad(IPassanger passanger);
        public void OfLoad();

    }
}
