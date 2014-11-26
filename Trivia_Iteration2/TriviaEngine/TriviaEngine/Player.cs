using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaEngine
{
    class Player
    {
        private Coordinates coordinates;
        private Spaceport curr;

        public Player(Spaceport curr)
        {
            this.coordinates = new Coordinates(0, 0);
            this.curr = curr;
        }

        public Coordinates getCoordinates()
        {
            return this.coordinates;
        }

        public Spaceport getCurr()
        {
            return this.curr;
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
