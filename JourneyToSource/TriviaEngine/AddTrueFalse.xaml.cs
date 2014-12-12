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
    /// Interaction logic for AddTrueFalse.xaml
    /// </summary>
    public partial class AddTrueFalse : Window
    {
        public AddTrueFalse()
        {
            InitializeComponent();
        }

        private void chkTrue_Checked(object sender, RoutedEventArgs e)
        {
            chkFalse.IsChecked = false; 
        }

        private void chkFalse_Checked(object sender, RoutedEventArgs e)
        {
            chkTrue.IsChecked = false; 
        }

        private void btnTransmit_Click(object sender, RoutedEventArgs e)
        {
            string question = "";
            char correct = 'z';
            question = tbxQuestion.Text;
            if (chkTrue.IsChecked == true)
                correct = 't';
            else if (chkFalse.IsChecked == true)
                correct = 'f';
            else
                MessageBox.Show("You must check true or false ro submit a question!");

            if (question != null && correct != 'z')
            {
                
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;
                
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

                    sqlite_cmd.CommandText = "INSERT INTO TrueAndFalse (Question, answer) VALUES ('" + question + "', '" +
                                             correct + "'  );";
                    sqlite_cmd.ExecuteNonQuery();

                    sqlite_conn.Close();
                    MessageBox.Show("Writing to the Database is complete!");
                    this.Close();
                }
            }
        }
    }
}
