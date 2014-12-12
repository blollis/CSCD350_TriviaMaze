using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaEngine
{
    public abstract class Question
    {
        public string question;
        public string correctAnswer;
        public IDisplayQuestion displayQuestion;
        public int result; 

        public Question(IDisplayQuestion displayQuestion, String question, String correctAnswer)
        {
            this.displayQuestion = displayQuestion;
            this.question = question;
            this.correctAnswer = correctAnswer;
            this.result = 0; 
        }

        protected string getQuestion()
        {
            return this.question;
        }

        protected string getAnswer()
        {
            return this.correctAnswer;
        }
        public void setResult(int result)
        {
            this.result = result; 
        }
    }
}
