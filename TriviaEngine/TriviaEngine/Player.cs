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

        public Player()
        {
            this.coordinates = new Coordinates(0, 0);
        }

        public Coordinates getCoordinates()
        {
            return this.coordinates;
        }

        public void setCoordinates(Coordinates coordinates)
        {
            this.coordinates = coordinates;
        }
        
    }
}
