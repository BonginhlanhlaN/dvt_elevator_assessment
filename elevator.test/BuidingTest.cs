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
    public class BuidingTest
    {

        [TestMethod]
        public void CreateElevators()
        {
            //Arrange 
            int numberOfElevators = 10;
            IBuilding building = new Building();

            //Act
            var buildingElevators = building.CreateElevators(numberOfElevators);

            //Assert
            Assert.AreEqual(buildingElevators.Count, numberOfElevators);

        }

        [TestMethod]
        public void CreateFloors()
        {

            int numberOfFloors = 10;
            IBuilding building = new Building();

            var buildingFloors = building.CreateFloors(numberOfFloors);

            Assert.AreEqual(buildingFloors.Count, numberOfFloors);

        }

        [TestMethod]
        public void ChooseNearestElevator()
        {

            List<IElevator> buildingElevators = new List<IElevator>() { 
                new Elevator() { 
                    Id = 1, 
                    CurrentFloor = 0, 
                    ToFloor = 0, 
                    Direction = (int)ElevatorDirections.Idle, 
                    Passagers = new List<IPassanger>()
                },
                new Elevator() {
                    Id = 2,
                    CurrentFloor = 4,
                    ToFloor = 0,
                    Direction = (int)ElevatorDirections.Idle,
                    Passagers = new List<IPassanger>()
                }
            };

            IBuilding building = new Building();
            building.Elevators = buildingElevators;

            IElevatorSummonRequest elevatorSummonRequest = new ElevatorSummonRequest() { 
                SummonedFloor = 1
            };

            var elevator = building.ChooseNearestElevator(elevatorSummonRequest);

            Assert.AreSame(buildingElevators[0] , elevator);


        }

        [TestMethod]
        public void UpdateElevatorAfterMove()
        {

            IBuilding building = new Building();

            List<IElevator> elevatorBeforeMove = new() {
                new Elevator() {
                    Id = 0,
                    CurrentFloor = 0,
                    ToFloor = 0,
                    Direction = (int)ElevatorDirections.Idle,
                    Passagers = new List<IPassanger>()
                }
               
            };


            building.Elevators = elevatorBeforeMove;

            IElevator elevatorAftereMove = new Elevator()
            {
                Id = 0,
                CurrentFloor = 2,
                ToFloor = 0,
                Direction = (int)ElevatorDirections.Idle,
                Passagers = new List<IPassanger>()
            };

            building.UpdateElevatorAfterMove(elevatorAftereMove);

            Assert.AreEqual(building.Elevators[0].CurrentFloor, elevatorAftereMove.CurrentFloor);

        }

    }
}
