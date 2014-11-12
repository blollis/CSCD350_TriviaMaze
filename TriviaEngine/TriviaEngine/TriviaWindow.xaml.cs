using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections;

namespace TriviaEngine
{
     public partial class TriviaWindow : Window
    {
         QuestionAndAnswer qa;
        public TriviaWindow()
        {
            InitializeComponent();
            triviaQuestion();
         
        }
        private void triviaQuestion()
        {
         
            
            getQuestion();
            setAnswers();
            QuestionField.Content = DisplayQuestion.QuestionDisplay(qa);
        }
        private void getQuestion()
        {
            ArrayList questionList = new ArrayList();
            questionList = DBQuestion.QueryQuestion();

            qa = new QuestionAndAnswer(questionList[1].ToString(), questionList[2].ToString(), questionList[3].ToString(), questionList[4].ToString(), questionList[5].ToString(), questionList[6].ToString());
        }// This method will need to get question form array or database. 
        //probably need to set it up as public with the array being sent in.
        private void setAnswers()
        {
            Answer1Button.Content = DisplayQuestion.Answer1Display(qa);
            Answer2Button.Content = DisplayQuestion.Answer2Display(qa);
            Answer3Button.Content = DisplayQuestion.Answer3Display(qa);
            Answer4Button.Content = DisplayQuestion.Answer4Display(qa);
        }
        private void CorrectAnswer()
        {
           // DoorUnlocked(true);
            MessageBox.Show("You are Correct! The Door is Open");
        }
        private void WrongAnswer()
        {
            //DoorUnlocked(false);
            MessageBox.Show("You are Incorrect. The Door is Forever Locked.");
        }
        // The buttons will have to send a value to a method so the door knows if it is
            // open or closed. Or with correct and wrong answer methods, send a value there.
        private void Answer1Button_Click(object sender, RoutedEventArgs e)
        {
            bool value = CompareAnswer.AnswerCheck(qa, 1);
            if(value == true)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            this.Close();

        }

        private void Answer2Button_Click(object sender, RoutedEventArgs e)
        {
            bool value = CompareAnswer.AnswerCheck(qa, 2);
            if (value == true)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            this.Close();
        }

        private void Answer3Button_Click(object sender, RoutedEventArgs e)
        {
            bool value = CompareAnswer.AnswerCheck(qa, 3);
            if (value == true)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            this.Close();
        }

        private void Answer4Button_Click(object sender, RoutedEventArgs e)
        {
            bool value = CompareAnswer.AnswerCheck(qa, 4);
            if (value == true)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            this.Close();
        }

        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            AddWuestionWindow win2 = new AddWuestionWindow();
            win2.Show(); 
        }
     }
}
