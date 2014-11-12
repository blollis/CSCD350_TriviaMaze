using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaEngine
{
    public static class DisplayQuestion
    {
        public static String QuestionDisplay(QuestionAndAnswer qanda)
        {
            return qanda.getQuestion();
        }// this will be changed to reflect the gui output.
        public static String Answer1Display(QuestionAndAnswer qanda)
        {
            return qanda.getAnswer1();
        }
        public static String Answer2Display(QuestionAndAnswer qanda)
        {
            return qanda.getAnswer2();
        }
        public static String Answer3Display(QuestionAndAnswer qanda)
        {
            return qanda.getAnswer3();
        }
        public static String Answer4Display(QuestionAndAnswer qanda)
        {
            return qanda.getAnswer4();
        }
    }
}
