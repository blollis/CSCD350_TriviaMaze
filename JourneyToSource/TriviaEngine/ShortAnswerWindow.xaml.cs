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
    /// Interaction logic for ShortAnswerWindow.xaml
    /// </summary>
    public partial class ShortAnswerWindow : Window
    {
        string answer;
        ShortAnswer SAQuestion; 
        
        public ShortAnswerWindow(ShortAnswer sa) : this()
        {
            InitializeComponent();
            tbxSAAnswer.Focus();
            SAQuestion = sa;
            tbxSAQuestion.Text = sa.question;
            answer = sa.correctAnswer;
        }

        public ShortAnswerWindow()
        {
            // TODO: Complete member initialization
        }

        private void btnTransmit_Click(object sender, RoutedEventArgs e)
        {
            string ans = tbxSAAnswer.Text;

            if (ans.Equals(""))
            {
                MessageBox.Show("You must input an answer to Transmit!");
            }

            else
            {
                if (ans.Equals(answer, StringComparison.InvariantCultureIgnoreCase))
                {

                    SAQuestion.setResult(1);
                    MessageBox.Show("Correct");
                }

                else
                    MessageBox.Show("Wrong");

                this.Close();
            }



        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnTransmit_Click(sender, e);
        }
    }
}
