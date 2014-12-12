using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TriviaEngine
{
    class DisplayMultipleChoice : IDisplayQuestion
    {
        public void displayQuestion(Question question)
        {
            MultipleChoice mc = (MultipleChoice)question;
            
            MultipleChoiceWindow multipleChoiceWindow = new MultipleChoiceWindow(mc);
            multipleChoiceWindow.ShowDialog();
        }
    }
}
