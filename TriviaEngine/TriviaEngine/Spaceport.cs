using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaEngine
{
    public class Spaceport
    {
     //   private Spaceport previous;
        private int portID;
        int numTrajectories;
        private Coordinates coordinates;
        private Trajectory[] trajectories;

        public Spaceport(int ID, Coordinates location )
        {
          //  this.previous = previous;
            this.portID = ID;
            this.coordinates = location;
          //  this.numTrajectories = numTrajectories;
          //  this.trajectories = new Trajectory[numTrajectories];
        }

        public int getPlanetID()
        {
            return this.portID;
        }

        public int getNumtrajectories()
        {
            return this.numTrajectories;
        }

        public Coordinates getCoordinates()
        {
            return this.coordinates;
        }
    }
}