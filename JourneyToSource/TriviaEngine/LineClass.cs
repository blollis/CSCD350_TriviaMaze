using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace TriviaEngine
{
    class LineClass
    {
        private Starmap map;
        private Line[][] lines;

        public LineClass(Starmap map, Line[][] lines)
        {
            this.map = map;
            this.lines = lines;
        }

        public void associateLines()
        {
        
            for(int i =0; i < 4; i++)
            {
                for(int j=0; j< 4; j++)
                {
                    for (int k = 0; k < map.getSpaceport(i, j).getTrajectories().Count(); k++)
                        map.getSpaceport(i, j).getTrajectories()[k].setLine(lines[j][k]);
                }
            }
        }

    }
}
