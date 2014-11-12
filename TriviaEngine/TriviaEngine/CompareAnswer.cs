using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaEngine
{
    public static class CompareAnswer
    {
        public static bool AnswerCheck(QuestionAndAnswer qanda,int answer)
        {
            if(answer==1)
            {
                if (String.Compare(qanda.getCorrectAnswer(),"a") == 0) 
                {
                    return true;
                }
                return false;
            }
            else if(answer==2)
            {
                if (String.Compare(qanda.getCorrectAnswer(),"b") == 0)
                {   
                    return true;
                }   
                return false;
            }
            else if(answer==3)
            {
                if (String.Compare(qanda.getCorrectAnswer(), "c") == 0)
                {
                    return true;
                }
                return false;
            }
            else if(answer==4)
            {
                if (String.Compare(qanda.getCorrectAnswer(), "d") == 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
