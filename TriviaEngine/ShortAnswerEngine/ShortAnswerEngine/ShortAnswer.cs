using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortAnswerEngine
{
    public class ShortAnswer
    {
        private string Question,Answer;
        public ShortAnswer(string Question,string Answer)
        {
            this.Question = Question;
            this.Answer = Answer;
        }
        public string getQuestion()
        {
            return Question;
        }
        public string getAnswer()
        {
            return Answer;
        }
    }
}
