using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SQLite; 

namespace TriviaEngine
{
    class DBQuestion
    {
        public static ArrayList QueryQuestion()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader, dr;

            ArrayList questionList = new ArrayList();
            questionList.Add(0);
            questionList.Add("*SPOILER ALERT* In Christopher Nolan's sci-fi action film Interstellar (2014),\n Matthew Mcconaughey's character is seen flying along the cusp of a mega black hole.\n Due to the aid of which extradimensional force is he able to avoid immediate vaporization\n and continue on to the mysterious event horizon?");
            questionList.Add("gravity");
            questionList.Add("love");
            questionList.Add("no");
            questionList.Add("WHAT IS GOING ON IN THIS MOVIE AHHHH");
            questionList.Add("a");
            /*
            // create a new SQL command:
            sqlite_conn = new SQLiteConnection("Data Source=questions.db;Version=3;New=True;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            Random r = new Random();
            int maxID = 6, temp;

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT MAX(question_ID) FROM Trivia";
            dr = sqlite_cmd.ExecuteReader();
            while (dr.Read())
            {
                maxID = dr.GetInt32(0);
            }
            sqlite_cmd.Dispose();
            temp = r.Next(1, maxID + 1);
            sqlite_cmd.CommandText = "SELECT question_ID, question, answer_a,  answer_b,  answer_c,  answer_d, answer_correct  FROM Trivia WHERE question_ID = '" + temp + "';";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                var question_id = sqlite_datareader.GetInt32(0);
                questionList.Add(Convert.ToString(question_id));


                var question = sqlite_datareader.GetString(1);
                questionList.Add(question);
                var qa = sqlite_datareader.GetString(2);
                questionList.Add(qa);

                var qb = sqlite_datareader.GetString(3);
                questionList.Add(qb);
                var qc = sqlite_datareader.GetString(4);
                questionList.Add(qc);
                var qd = sqlite_datareader.GetString(5);
                questionList.Add(qd);
                var ans = sqlite_datareader.GetString(6);
                questionList.Add(ans);
            }

            sqlite_cmd.Connection.Close();
            sqlite_cmd.Dispose();
            */
            return questionList; 

        }
    }
}
