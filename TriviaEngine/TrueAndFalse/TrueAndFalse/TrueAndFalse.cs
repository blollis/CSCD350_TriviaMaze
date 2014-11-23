using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueAndFalse
{
    public class TrueAndFalseQuestion
    {
        private string question;
        private char correctAnswer;
        public TrueAndFalseQuestion(string question,char correctAnswer)
        {
            this.question = question;
            this.correctAnswer = correctAnswer;
        }
        public string getQuestion()
        {
            return question;
        }
        public char getCorrectAnswer()
        {
            return correctAnswer;
        }
    }
}
