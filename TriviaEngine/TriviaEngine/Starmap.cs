using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaEngine
{
    class Starmap
    {
        private Spaceport[,] spaceports;
        private int width;
        private int height;

        public Starmap(int width, int height)
        {
            this.spaceports = new Spaceport[width,height];
            this.width = width;
            this.height = height;
        }

        public Spaceport getSpaceport(int x, int y)
        {
            return spaceports[x, y];
        }

        public void initialize()
        {
           int ID=0;
             for(int i=0; i<this.width-1; i++)
             {
               
                 for(int j=0; j<this.height-1; j++)
                 {
                     spaceports[i, j] = new Spaceport(ID, new Coordinates(i, j));
                 }
             }
        }
    }
}
