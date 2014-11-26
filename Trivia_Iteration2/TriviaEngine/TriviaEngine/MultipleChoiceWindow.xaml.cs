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

namespace TriviaEngine
{
    /// <summary>
    /// Interaction logic for MultipleChoiceWindow.xaml
    /// </summary>
    public partial class MultipleChoiceWindow : Window
    {
        string answer;
        MultipleChoice q1; 
        public MultipleChoiceWindow(MultipleChoice mc) : this()
        {
            //this.question = question; 
            InitializeComponent();
            q1 = mc;
            tbxQuestion.Text = mc.question;
            btnA.Content = mc.answer1;
            btnB.Content = mc.answer2;
            btnC.Content = mc.answer3;
            btnD.Content = mc.answer4;

            answer = mc.correctAnswer;
           
        }

        public MultipleChoiceWindow()
        {
            // TODO: Complete member initialization
        }

        private void btnA_Click(object sender, RoutedEventArgs e)
        {
            if (answer.Equals("a"))
            {
                MessageBox.Show("Correct");
                q1.setResult(1);
            }
            else
                MessageBox.Show("Wrong");
            this.Close(); 
        }

        private void btnB_Click(object sender, RoutedEventArgs e)
        {
            if (answer.Equals("b"))
            {
                MessageBox.Show("Correct");
                q1.setResult(1);
            }
            else
                MessageBox.Show("Wrong");
            this.Close(); 
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            if (answer.Equals("c"))
            {
                MessageBox.Show("Correct");
                q1.setResult(1);
            }
            else
                MessageBox.Show("Wrong");
            this.Close(); 
            
        }

        private void btnD_Click(object sender, RoutedEventArgs e)
        {
            if (answer.Equals("d"))
            {
                MessageBox.Show("Correct");
                q1.setResult(1);
            }
            else
                MessageBox.Show("Wrong");
            this.Close(); 
        }
    }
}
