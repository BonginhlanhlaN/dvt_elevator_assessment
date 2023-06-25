using elevator.console.Enums;
using elevator.console.Implementations;
using elevator.console.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevator.test
{

    [TestClass]
    public class ElevatorTest
    {


        [TestMethod]
        public void MoveToRequestedFloor()
        {

            IElevatorSummonRequest elevatorRequest = new ElevatorSummonRequest();
            elevatorRequest.SummonedFloor = 2;

            int toFloorBeforSummonRequest = 0;
            IElevator elevator = new Elevator()
            {
                Id = 0,
                CurrentFloor = 0,
                ToFloor = toFloorBeforSummonRequest,
                Direction = (int)ElevatorDirections.Idle,
                Passagers = new List<IPassanger>()
            };
               
            elevator.MoveToRequestedFloor(elevatorRequest);

            Assert.AreNotEqual(elevator.ToFloor , toFloorBeforSummonRequest);

        }

        [TestMethod]
        public void DropOffPassagersToSummedFloor()
        {

            List<IPassanger> passangers = new() { 
            
                new Passager()
                {
                    FromFloor = 2,
                    ToFloor = 4
                },
                new Passager()
                {
                    FromFloor = 1,
                    ToFloor = 2
                }

            };

            IElevator elevator = new Elevator()
            {
                Id = 0,
                CurrentFloor = 1,
                ToFloor = 3,
                Direction = (int)ElevatorDirections.Idle,
                Passagers = passangers.ToList()
            };

            elevator.DropOffPassagersToSummedFloor();

            Assert.AreNotEqual(elevator.Passagers.Count, passangers.Count);

        }

        [TestMethod]
        public void MoveToDestinationFloor()
        {

            IElevatorDestinationRequest elevatorRequest = new ElevatorDestinationRequest();
            elevatorRequest.DestinationFloor = 2;

            int toFloorBeforSummonRequest = 0;
            IElevator elevator = new Elevator()
            {
                Id = 0,
                CurrentFloor = 0,
                ToFloor = toFloorBeforSummonRequest,
                Direction = (int)ElevatorDirections.Idle,
                Passagers = new List<IPassanger>()
            };

            elevator.MoveToDestinationFloor(elevatorRequest);

            Assert.AreNotEqual(elevator.ToFloor, toFloorBeforSummonRequest);

        }

        [TestMethod]
        public void DropOffPassagersToDestination()
        {

            List<IPassanger> passangers = new()
            {

                new Passager()
                {
                    FromFloor = 2,
                    ToFloor = 4
                },
                new Passager()
                {
                    FromFloor = 1,
                    ToFloor = 2
                }

            };

            IElevator elevator = new Elevator()
            {
                Id = 0,
                CurrentFloor = 1,
                ToFloor = 3,
                Direction = (int)ElevatorDirections.Idle,
                Passagers = passangers.ToList()
            };

            elevator.DropOffPassagersToSummedFloor();

            Assert.AreNotEqual(elevator.Passagers.Count, passangers.Count);

        }

        [TestMethod]
        public void ChooseNearestElevator()
        {

            IElevator elevator = new Elevator()
            {
                Id = 0,
                CurrentFloor = 0,
                ToFloor = 1,
                Direction = (int)ElevatorDirections.Idle,
                Passagers = new List<IPassanger>()
            };

            IPassanger pasager = new Passager()
            {
                FromFloor = 2,
                ToFloor = 4
            };

            elevator.OnLoad(pasager);
            Assert.AreNotEqual(elevator.Passagers.Count, 0);

        }

    }
}
