using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ALL_TOGETHER.NewFolder
{
    internal class ElevatorManager
    {
        List<Elevator> list = new List<Elevator>();
        Queue<int> requests = new Queue<int>(); //One worker to listens to
        //Other workers to handle
        //Work in a while loop and listens to constants request!

        public void ElevatorRequest(int floorNumber)
        {
            //find which one is closest and sends it
            //Calculates which one is the best to be sent

            var foundElevator = FindTheBestOneToSend(floorNumber);

            foundElevator.GoUp(floorNumber);
            
            foundElevator.GoDown(floorNumber);

            //Prepare floor program List<int> program
            foundElevator.UpdateFloorPorgram(/*List*/);
        }

        public Elevator FindTheBestOneToSend(int floorNumber)
        {
            //From, To, Current Location and sends the closest
            //Calculates the shortest way to arrive and picks bu it
            return null;
        }
    }
}
