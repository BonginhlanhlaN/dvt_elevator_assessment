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

        public List<IPassanger> Passagers { get; set; }
        public int CurrentFloor { get; set; }
        public int ToFloor { get; set; }
        public int Direction { get; set; }



        public async Task Move()
        {

            await Task.Run(() => {

                Console.WriteLine("Elevator Started Moving");
                Thread.Sleep(3000);
                Console.WriteLine("Elevator Finished Moving");

            });

        }

        public void OnLoad()
        {
            Console.WriteLine("Elevatore dropped off somebody");
        }
        public void OfLoad()
        {

            Console.WriteLine("Elevatore picked up somebody");

        }
    }
}
