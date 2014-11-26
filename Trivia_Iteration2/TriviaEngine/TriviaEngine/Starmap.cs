using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private int x;
        private int count = 0;
        public void initialize()
        {
           int[] exits = new int[16] {2,3,3,2,3,4,4,3,3,4,4,3,2,3,3,2};
           int ID=0;
             for(int i=0; i<this.width; i++)
             {
               
                 for(int j=0; j<this.height; j++)
                 {
                     spaceports[i, j] = new Spaceport(ID, new Coordinates(i, j));
                     spaceports[i, j].initializeTrajectories();
                     spaceports[i, j].setNumExits(spaceports[i, j].getTrajectories().Count());
                     count++;
                 }
             }
        }
    }
}
