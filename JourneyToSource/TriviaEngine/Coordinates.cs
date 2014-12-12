using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//
using System.Runtime.Serialization;//
using System.Runtime.Serialization.Formatters.Binary;

namespace TriviaEngine
{
    [Serializable()]
    public class Coordinates
    {
        private int x;
        private int y;

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public void advanceX()
        {
            this.x++;
        }
        public void advanceY()
        {
            this.y++;
        }
        public void decrementX()
        {
            this.x--;
        }
        public void decrementY()
        {
            this.y--;
        }
        public bool Equals(Coordinates obj)
        {
            if (this.getX() == obj.getX() && this.getY() == obj.getY()) 
            return true;
            return false;
        }
    }

}