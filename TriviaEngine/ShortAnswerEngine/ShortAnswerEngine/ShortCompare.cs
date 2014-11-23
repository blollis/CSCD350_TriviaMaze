using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortAnswerEngine
{
    public static class ShortCompare
    {
        public static int CompareShort(ShortAnswer sa, string userAnswer)
        {
          /*  if(sa.getAnswer().Equals(userAnswer,StringComparison.OrdinalIgnoreCase))
            {
                return true;
           }
           return false;*/
           return String.Compare(sa.getAnswer(), userAnswer, StringComparison.OrdinalIgnoreCase);
        }
    }
}
