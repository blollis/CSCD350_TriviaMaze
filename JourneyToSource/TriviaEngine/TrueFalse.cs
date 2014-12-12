using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaEngine
{
    public class TrueFalse : Question
    {

        public TrueFalse(IDisplayQuestion displayQuestion, String question, String correctAnswer)
            : base(displayQuestion, question, correctAnswer)
        {
            
        }

    }
}
