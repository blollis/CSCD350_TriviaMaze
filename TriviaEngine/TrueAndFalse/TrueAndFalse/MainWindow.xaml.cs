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

namespace TrueAndFalse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TrueAndFalseQuestion taf;
        public MainWindow()
        {
            InitializeComponent();
            getQuestion();
            QuestionField.Content = TrueFalseDisplay.DisplayTrueFalse(taf);
        }
        private void getQuestion()
        {/// this method needs to be changed just like Trivia Engine.
            taf = new TrueAndFalseQuestion("Is kendo Awesome?", 't');
        }
        private void correctAnswer()
        {
            MessageBox.Show("You are correct. The Door is unlocked.");
        }
        private void wrongAnswer()
        {
            MessageBox.Show("You are wrong. The door is sealed forever.");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool value = CompareTrueOrFalse.Answer(taf, 1);
            if(value==true)
            {
                correctAnswer();
            }
            else if(value==false)
            {
                wrongAnswer();
            }
            this.Close();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool value = CompareTrueOrFalse.Answer(taf, 2);
            if (value == true)
            {
                correctAnswer();
            }
            else if (value == false)
            {
                wrongAnswer();
            }
            this.Close();
        }
    }
}
