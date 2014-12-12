using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaEngine
{
    [Serializable()]
    public class Player
    {
        private Coordinates coordinates;
        private Spaceport curr;
        private int fuel;

        public Player(Spaceport curr)
        {
            this.coordinates = new Coordinates(0, 0);
            this.curr = curr;
            this.fuel = 0;
        }

        public Coordinates getCoordinates()
        {
            return this.coordinates;
        }

        public int getFuel()
        {
            return this.fuel;
        }

        public Spaceport getCurr()
        {
            return this.curr;
        }

        public void setFuel()
        {
            this.fuel++;
        }

        public void setFuel(int x)
        {
            this.fuel=x;
        }

        public void setCoordinates(Coordinates coordinates)
        {
            this.coordinates = coordinates;
        }

        public void setSpaceport(Spaceport asdf)
        {
            this.curr = asdf;
        }

        
    }
}
