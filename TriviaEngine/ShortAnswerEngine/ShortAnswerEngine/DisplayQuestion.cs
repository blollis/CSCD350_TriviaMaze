using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortAnswerEngine
{
    public static class DisplayQuestion
    {
        public static string QuestionDisplay(ShortAnswer sa)
        {
            return sa.getQuestion();
        }
    }
}
