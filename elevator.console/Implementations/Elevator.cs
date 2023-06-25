using elevator.console.Enums;
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
        public int MaxPassagerNum { get; set; } = 10;



        public void MoveToRequestedFloor(IElevatorSummonRequest elevatorRequest)
        {

            string elevetorDirection = elevatorRequest.SummonedFloor > this.CurrentFloor ? "Elevator Going Up " : " Elevator Going Down ";
            string passagerElevatoreFloors = " from Floor " + this.CurrentFloor + " to floor " + elevatorRequest.SummonedFloor;
            string numberOfPassagers = " Carrying " + this.Passagers.Count + " Passager(s)";

            Console.WriteLine(elevetorDirection + passagerElevatoreFloors + numberOfPassagers);

            
            if (this.CurrentFloor < elevatorRequest.SummonedFloor)
            {

                this.Direction = (int)ElevatorDirections.MovingUp;

            }else if(this.CurrentFloor > elevatorRequest.SummonedFloor)
            {
                this.Direction = (int)ElevatorDirections.MovingDown;
            }
            else
            {
                this.Direction = (int)ElevatorDirections.Idle;
            }

            this.ToFloor = elevatorRequest.SummonedFloor;

            //await Task.Run(() => {

            //    Console.WriteLine("Elevator Started Moving");
            //    Thread.Sleep(3000);
            //    Console.WriteLine("Elevator Finished Moving");

            //});

        }



        public void DropOffPassagersToSummedFloor()
        {

            //Takes care of dropping off passagers on the way to the summoned Floor

            int currentIterationIndex = 0;
            int numberOfPassagersDroppedOff = 0;
            foreach (IPassanger passsager in this.Passagers.ToList())
            {
                /**If the destination of the elavtor is carrying lies in between the Floor the elavator is currently in 
                 * and the floor it's going too,
                 * dropp them off.
                 */
                if(Enumerable.Range(this.CurrentFloor, this.ToFloor).Contains(passsager.ToFloor))
                {
                    this.Passagers.RemoveAt(currentIterationIndex);
                    numberOfPassagersDroppedOff++;
                }

            }

            if (numberOfPassagersDroppedOff > 0) { Console.WriteLine("Dropped Off Passagers."); }


        }

        public void MoveToDestinationFloor(IElevatorDestinationRequest elevatorRequest)
        {

            //When the elevator Reaches the requested floor the requested floor(Previos ToFloor) then becomes the Current Floor of the elevator.
            this.CurrentFloor = this.ToFloor;

            string elevetorDirection = elevatorRequest.DestinationFloor > this.CurrentFloor ? "Elevator Going Up " : "Elevator Going Down ";
            string passagerElevatoreFloors = " from Floor " + this.CurrentFloor + " to floor " + elevatorRequest.DestinationFloor;
            string numberOfPassagers = " Carrying " + this.Passagers.Count + " Passager(s)";

            Console.WriteLine(elevetorDirection + passagerElevatoreFloors + numberOfPassagers);

            if (this.CurrentFloor < elevatorRequest.DestinationFloor)
            {

                this.Direction = (int)ElevatorDirections.MovingUp;

            }
            else if (this.CurrentFloor > elevatorRequest.DestinationFloor)
            {
                this.Direction = (int)ElevatorDirections.MovingDown;
            }
            else
            {
                this.Direction = (int)ElevatorDirections.Idle;
            }

            this.ToFloor = elevatorRequest.DestinationFloor;

        }

        public void DropOffPassagersToDestination()
        {

            //Takes care of dropping off passagers on the way to the destination floor

            int currentIterationIndex = 0;
            int numberOfPassagersDroppedOff = 0;
            foreach (IPassanger passsager in this.Passagers.ToList())
            {
                /**If the destination of the Passager that the elavtor is carrying lies in between the Floor the elavator is currently in 
                 * and the floor it's going too,
                 * dropp them off.
                 */
                if (Enumerable.Range(this.CurrentFloor, this.ToFloor).Contains(passsager.ToFloor))
                {
                    this.Passagers.RemoveAt(currentIterationIndex);
                    numberOfPassagersDroppedOff++;
                }

            }

            if (numberOfPassagersDroppedOff > 0) { Console.WriteLine("Dropped Off Passagers."); }


        }

        public void OnLoad(IPassanger passanger)
        {


            /**
             * Takes care of onLoading a Passager
             * **/
            Console.WriteLine("Elevator picked you up on floor " + passanger.FromFloor + ". Now heading to floor " + passanger.ToFloor);
            this.CurrentFloor = passanger.FromFloor;
            this.Passagers.Add(passanger);

        }
       
    }
}
