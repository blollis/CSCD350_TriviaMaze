using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaEngine
{
    public class ShortAnswer : Question
    {
       
        public ShortAnswer(IDisplayQuestion displayQuestion,  string question, string correctAnswer)
            : base (displayQuestion, question, correctAnswer)

        {
        
        }
 
    }
}
