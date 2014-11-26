using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaEngine
{
   public class Trajectory
    {
        private Coordinates target;
        private int locked; //0=open 1=locked 2=sealed

        public Trajectory(Coordinates coordinates, int locked)
        {
            this.target = coordinates;
            this.locked = locked;
        }

       public Coordinates getCoordinates()
       {
           return this.target;
       }

       public int getLocked()
       {
           return this.locked;
       }

       public void setLocked(int x)
       {
           this.locked = x;
       }

    }
}
