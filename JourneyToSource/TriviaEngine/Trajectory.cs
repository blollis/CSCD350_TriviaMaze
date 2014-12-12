using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.IO;//
using System.Runtime.Serialization;//
using System.Runtime.Serialization.Formatters.Binary;


namespace TriviaEngine
{
    [Serializable()]
    
   public class Trajectory
    {
        private Coordinates target;
        private int locked; //0=open 1=locked 2=sealed
        private Line line;
        
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

       public void setLine(Line line)
       {
           this.line = line;
       }


    }
}
