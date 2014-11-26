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
            MessageBox.Show("ShortAnsswer");
        }
    }
}
