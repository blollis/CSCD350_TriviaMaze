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
    /// Interaction logic for TrueFalseWindow.xaml
    /// </summary>
    public partial class TrueFalseWindow : Window
    {

        string answer;
        TrueFalse TFQuestion;
        public TrueFalseWindow(TrueFalse tf) : this()
        {
            InitializeComponent();
            TFQuestion = tf;
            tbxTFQuestion.Text = tf.question;
            answer = tf.correctAnswer; 

        }

        public TrueFalseWindow()
        {
            // TODO: Complete member initialization
        }

        private void btnTrue_Click(object sender, RoutedEventArgs e)
        {
            if (answer.Equals("t"))
            {
                MessageBox.Show("Correct");
                TFQuestion.setResult(1);
            }

            else
                MessageBox.Show("Wrong");

            this.Close();
        }

        private void btnFalse_Click(object sender, RoutedEventArgs e)
        {
            if (answer.Equals("f"))
            {
                MessageBox.Show("Correct");
                TFQuestion.setResult(1);
            }

            else
                MessageBox.Show("Wrong");

            this.Close();
        }
    }
}
