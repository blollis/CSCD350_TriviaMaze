using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaEngine
{
    public class QuestionAndAnswer
    {
        private string question, answer1, answer2, answer3, answer4, answer;
        
        public QuestionAndAnswer(string question, string answer1, string answer2, string answer3, string answer4, string answer)
        {
            this.question = question;
            this.answer1 = answer1;
            this.answer2 = answer2;
            this.answer3 = answer3;
            this.answer4 = answer4;
            this.answer = answer;
        }
        public string getQuestion()
        {
            return question;
        }
        public string getAnswer1()
        {
            return answer1;
        }
        public string getAnswer2()
        {
            return answer2;
        }
        public string getAnswer3()
        {
            return answer3;
        }
        public string getAnswer4()
        {
            return answer4;
        }
        public string getCorrectAnswer()
        {
            return answer;
        }
    }
}
