using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueAndFalse
{
    public static class CompareTrueOrFalse
    {
        public static bool Answer(TrueAndFalseQuestion q,int buttonID)
        {
            if(buttonID==1)
            {
                if(q.getCorrectAnswer()=='t')
                {
                    return true;
                }
                return false;
            }
            else if(buttonID==2)
            {
                if(q.getCorrectAnswer()=='f')
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
