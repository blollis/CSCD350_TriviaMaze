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
    /// Interaction logic for AddShortAnswer.xaml
    /// </summary>
    public partial class AddShortAnswer : Window
    {
        public AddShortAnswer()
        {
            InitializeComponent();
        }

        private void btnTransmit_Click(object sender, RoutedEventArgs e)
        {
            string question = "";
            string correct = "";
            question = tbxQuestion.Text;
            correct = tbxAnswer.Text;

            if (string.IsNullOrWhiteSpace(tbxQuestion.Text) || string.IsNullOrWhiteSpace(tbxAnswer.Text))
                MessageBox.Show("You must enter the question/answer");

            else
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

                    sqlite_cmd.CommandText = "INSERT INTO ShortAnswer (Question, answer) VALUES ('" + question + "', '" + correct + "'  );";
                    sqlite_cmd.ExecuteNonQuery();

                    sqlite_conn.Close();
                    MessageBox.Show("Writing to the Database is complete!");
                    this.Close();
                }
            }
        }
    }
}
