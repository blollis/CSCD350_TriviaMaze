using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TriviaEngine
{
    internal class QuestionFactory
    {
        public ArrayList resultList = new ArrayList();

        public ArrayList mcList = new ArrayList();
        public ArrayList saList = new ArrayList();
        public ArrayList tfList = new ArrayList();

        public Question CreateQuestion(int type)
        {
            resultList.Clear();
            if (type < 51)
            {
                QuestionQuery("MultipleChoice");
                return new MultipleChoice(new DisplayMultipleChoice(), resultList[1].ToString(),
                    resultList[6].ToString(), resultList[2].ToString(), resultList[3].ToString(),
                    resultList[4].ToString(), resultList[5].ToString());
            }
            else if (type < 75)
            {
                QuestionQuery("ShortAnswer");
                return new ShortAnswer(new DisplayShortAnswer(), resultList[1].ToString(), resultList[2].ToString());
            }
            else
            {
                QuestionQuery("TrueAndFalse");
                return new TrueFalse(new DisplayTrueFalse(), resultList[1].ToString(), resultList[2].ToString());
            }
        }

        public void QuestionQuery(String tableName)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader, dr;
            sqlite_conn = new SQLiteConnection("Data Source=Questions.s3db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();
            bool doubleQuestion = false;
            int maxID = 0, temp = 1;
            do
            {
                Random r = new Random();

                sqlite_cmd = sqlite_conn.CreateCommand();


                sqlite_cmd.CommandText = "SELECT MAX(QuestionID) FROM '" + tableName + "';";

                dr = sqlite_cmd.ExecuteReader();
                while (dr.Read())
                {
                    maxID = dr.GetInt32(0);
                }
                sqlite_cmd.Dispose();
                temp = r.Next(1, maxID + 1);
                doubleQuestion = checkDoubleQuestion(tableName, temp, mcList, saList, tfList);
            } while (doubleQuestion == true);


            if (tableName.Equals("MultipleChoice"))
                mcList.Add(temp);

            else if (tableName.Equals("ShortAnswer"))
                saList.Add(temp);

            else if (tableName.Equals("TrueAndFalse"))
                tfList.Add(temp);



            if (tableName.Equals("MultipleChoice"))
            {
                sqlite_cmd.CommandText =
                    "SELECT QuestionID, Question, answer_a,  answer_b,  answer_c,  answer_d, correct_answer  FROM '" +
                    tableName + "' WHERE QuestionID = '" + temp + "';";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    var QuestionID = sqlite_datareader.GetInt32(0);
                    resultList.Add(Convert.ToString(QuestionID));
                    var question = sqlite_datareader.GetString(1);
                    resultList.Add(question);
                    var qa = sqlite_datareader.GetString(2);
                    resultList.Add(qa);
                    var qb = sqlite_datareader.GetString(3);
                    resultList.Add(qb);
                    var qc = sqlite_datareader.GetString(4);
                    resultList.Add(qc);
                    var qd = sqlite_datareader.GetString(5);
                    resultList.Add(qd);
                    var ans = sqlite_datareader.GetString(6);
                    resultList.Add(ans);
                }
            }
            else
            {
                sqlite_cmd.CommandText =
                    "SELECT QuestionID, Question, answer  FROM '" +
                    tableName + "' WHERE QuestionID = '" + temp + "';";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    var QuestionID = sqlite_datareader.GetInt32(0);
                    resultList.Add(Convert.ToString(QuestionID));
                    var question = sqlite_datareader.GetString(1);
                    resultList.Add(question);
                    var ans = sqlite_datareader.GetString(2);
                    resultList.Add(ans);
                }

            }
            sqlite_cmd.Connection.Close();
            sqlite_cmd.Dispose();
        }
        public bool checkDoubleQuestion(string tableName, int qID, ArrayList mcList, ArrayList saList, ArrayList tfList)
        {
            if (tableName.Equals("MultipleChoice"))
            {
                if (mcList.Contains(qID))
                    return true;
            }

            else if (tableName.Equals("ShortAnswer"))
            {
                if (saList.Contains(qID))
                    return true;
            }

            else if (tableName.Equals("TrueAndFalse"))
            {
                if (tfList.Contains(qID))
                    return true;
            }

            return false;
        }
    }
}