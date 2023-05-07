using System;
using System.Collections.Generic;
using System.Text;

namespace ALL_TOGETHER.NewFolder
{
    //https://codereview.stackexchange.com/questions/161431/elevator-interview-problem-oop
    public enum ElevatorStatus
    {
        ARRIVED,
        GOING_UP,
        GOING_DOWN
    }
    internal class Elevator
    {
        List<int> FloorProgram { get; set; }
        public int CurrentFloor { get; set; }
        public int FloorDestination { get; set; }
        public ElevatorStatus Status { get; set; }
        public int Velocity { get; set; }
        public void Stop() { }
        public void GoUp(int floorNUmber) { }
        public void GoDown(int floorNUmber) { }
        public void UpdateFloorPorgram(/*list*/) { }

    }
}
