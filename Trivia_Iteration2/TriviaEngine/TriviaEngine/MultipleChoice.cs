using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaEngine
{
    public class MultipleChoice : Question
    {
        public string answer1, answer2, answer3, answer4;

        public MultipleChoice(IDisplayQuestion displayQuestion, String question, String correctAnswer, String answer1, String answer2, String answer3, String answer4)
            : base(displayQuestion, question, correctAnswer)
        {
            this.answer1 = answer1;
            this.answer2 = answer2;
            this.answer3 = answer3;
            this.answer4 = answer4;
        }
 
    }
}
