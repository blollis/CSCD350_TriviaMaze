﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace TriviaEngine
{
    class DisplayTrueFalse : IDisplayQuestion
    {
        public void displayQuestion(Question question)
        {
            TrueFalse tf = (TrueFalse)question;

            TrueFalseWindow trueFalseWindow = new TrueFalseWindow(tf);
            trueFalseWindow.ShowDialog();
        }
    }
}
