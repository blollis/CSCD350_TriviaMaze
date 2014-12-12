using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace TriviaEngine
{
    class DisplayShortAnswer : IDisplayQuestion
    {
        public void displayQuestion(Question question)
        {
            ShortAnswer sa = (ShortAnswer)question;

            ShortAnswerWindow shortAnswerWindow = new ShortAnswerWindow(sa);
            shortAnswerWindow.ShowDialog();
        }
    }
}
