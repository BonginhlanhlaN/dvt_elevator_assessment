using elevator.console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace elevator.console.Implementations
{
    public class Elevator : IElevator
    {

        public int Id { get; set; }
        public List<IPassanger> Passagers { get; set; }
        public int CurrentFloor { get; set; }
        public int ToFloor { get; set; }
        public int Direction { get; set; }



        public void Move(IPassanger passanger)
        {

            string elevetorDirection = passanger.FromFloor > this.CurrentFloor ? " Elevator Going Up " : " Elevator Going Down ";
            string passagerElevatoreFloors = " from Floor " + this.CurrentFloor + " to floor " + passanger.FromFloor;
            string numberOfPassagers = " Carrying " + this.Passagers.Count + " Passagers";

            Console.WriteLine(elevetorDirection + passagerElevatoreFloors + numberOfPassagers);

            //await Task.Run(() => {

            //    Console.WriteLine("Elevator Started Moving");
            //    Thread.Sleep(3000);
            //    Console.WriteLine("Elevator Finished Moving");

            //});

        }

        public void OnLoad(IPassanger passanger)
        {

            Console.WriteLine("Elevator picked up somebody on floor " + passanger.FromFloor);
            this.Passagers.Add(passanger);

        }
        public void OfLoad()
        {

            Console.WriteLine("Elevator dropped off somebody on floor ");

        }
    }
}
