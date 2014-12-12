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
using System.Data.SQLite; 
using System.IO; 

namespace TriviaEngine
{
    /// <summary>
    /// Interaction logic for AddWuestionWindow.xaml
    /// </summary>
    public partial class AddWuestionWindow : Window
    {
        public AddWuestionWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string question = "", a = "", b = "", c = "", d = "";
            char correct = 'z';
            question = tbxQuestion.Text;
            a = tbxA.Text;
            b = tbxB.Text;
            c = tbxC.Text;
            d = tbxD.Text;

            if (chkA.IsChecked == true)
                correct = 'a';

            else if (chkB.IsChecked == true)
                correct = 'b';

            else if (chkC.IsChecked == true)
                correct = 'c';

            else if (chkD.IsChecked == true)
                correct = 'd';

            else
                MessageBox.Show("You must check the correct answer!");

            if (question != null && a != null && b != null && c != null && d != null && correct != 'z')
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;
                //SQLiteDataReader sqlite_datareader;


                string db = "Questions.s3db";
                if (!File.Exists(db))
                {
                    MessageBox.Show("The database file does not exist!");
                }
                else
                {
                    sqlite_conn = new SQLiteConnection("Data Source=Questions.s3db;Version=3;New=True;Compress=True;");
                    sqlite_conn.Open();
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    sqlite_cmd.CommandText = "INSERT INTO MultipleChoice (Question, answer_a, answer_b, answer_c, answer_d, correct_answer) VALUES ('" + question + "', '" + a + "','" + b + "','" + c + "', '" + d + "', '" + correct + "'  );";
                    sqlite_cmd.ExecuteNonQuery();

                    sqlite_conn.Close();
                    MessageBox.Show("Writing to the Database is complete!");
                    this.Close();
                }
            }
        }

        private void chkA_Checked(object sender, RoutedEventArgs e)
        {
            chkB.IsChecked = false;
            chkC.IsChecked = false;
            chkD.IsChecked = false;
        }

        private void chkB_Checked(object sender, RoutedEventArgs e)
        {
            chkA.IsChecked = false;
            chkC.IsChecked = false;
            chkD.IsChecked = false;
        }

        private void chkC_Checked(object sender, RoutedEventArgs e)
        {
            chkA.IsChecked = false;
            chkB.IsChecked = false;
            chkD.IsChecked = false;
        }

        private void chkD_Checked(object sender, RoutedEventArgs e)
        {
            chkA.IsChecked = false;
            chkB.IsChecked = false;
            chkC.IsChecked = false;
        }
    }
}
