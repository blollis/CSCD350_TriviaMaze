using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Shapes;
using System.IO;//
using System.Runtime.Serialization;//
using System.Runtime.Serialization.Formatters.Binary;

namespace TriviaEngine
{
    [Serializable()]
    public class Spaceport
    {
     //   private Spaceport previous;
        private int portID;
        private int numExits;
        private Coordinates coordinates;
        private int canvasX;
        private int canvasY;
        [NonSerialized()] private List<Trajectory> trajectories = new List<Trajectory>();
        [NonSerialized()] private List<Line> lineList = new List<Line>();
       

        public Spaceport(int ID, Coordinates location  )
        {
          //  this.previous = previous;
            this.portID = ID;
            this.coordinates = location;
          
            //  this.numTrajectories = numTrajectories;
            //  this.trajectories = new Trajectory[numTrajectories];
        }

        public void setLineList(List<Line> lineList)
        { 
            this.lineList = lineList;
        }
        public void setCanvasXY(int x, int y)
        {
            this.canvasX = x;
            this.canvasY = y;
        }

        public int getCanvasX()
        {
            return this.canvasX;
        }

        public int getCanvasY()
        {
            return this.canvasY;
        }

        public List<Trajectory> getTrajectories()
        {
            return this.trajectories;
        }
        public List<Line> getLines()
        {
            return this.lineList;
        }

        public void setNumExits(int x)
        {
            this.numExits = x;
        }

        public int getPlanetID()
        {
            return this.portID;
        }

        public int getNumtrajectories()
        {
            return this.numExits;
        }

        public Coordinates getCoordinates()
        {
            return this.coordinates;
        }

        public void initializeTrajectories()
        {
            
            if(isValid(this.coordinates.getX()-1, this.coordinates.getY()+1))//n
            {
                this.trajectories.Add(new Trajectory(new Coordinates(this.coordinates.getX() - 1, this.coordinates.getY() + 1), 1));
            }
            if (isValid(this.coordinates.getX() +1, this.coordinates.getY() -1))//s
            {
                this.trajectories.Add(new Trajectory(new Coordinates(this.coordinates.getX() +1 , this.coordinates.getY() -1 ), 1));
            }
            if (isValid(this.coordinates.getX() , this.coordinates.getY() + 1))//ne
            {
                this.trajectories.Add(new Trajectory(new Coordinates(this.coordinates.getX(), this.coordinates.getY() + 1), 1));
            }
            if (isValid(this.coordinates.getX() + 1, this.coordinates.getY() ))//se
            {
                this.trajectories.Add(new Trajectory(new Coordinates(this.coordinates.getX() +1, this.coordinates.getY()), 1));
            }
            
        }

        public Boolean isValid(int x, int y)
        {
            if (x >= 0 && y >= 0)
            {
                if (x < 4 && y < 4)
                {
                    return true;
                }
            }
            return false;
        }

    }
}