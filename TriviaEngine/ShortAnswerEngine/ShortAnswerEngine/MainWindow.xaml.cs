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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShortAnswerEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShortAnswer sa;
        public MainWindow()
        {
            InitializeComponent();
            getQuestion();
            QuestionField.Content=DisplayQuestion.QuestionDisplay(sa);
        }
        private void getQuestion()
        {
            sa = new ShortAnswer("What are the two weapons used in Kendo?","Shinai and Bokken ");
        }
        private void ShortAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void showAnswer(string line)
        {
            MessageBox.Show(line);
        }
        private void correctAnswer()
        {
            MessageBox.Show("You are correct. The Door is Open.");
        }
        private void wrongAnswer()
        {
            MessageBox.Show("You are wrong. The Door is Sealed forever.");
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string playerAnswer = this.ShortAnswer.Text;
            if(ShortCompare.CompareShort(sa,playerAnswer)==0)
            {
                correctAnswer();
            }
            else
            {
                wrongAnswer();
            }
            this.Close();
        }
    }
}
