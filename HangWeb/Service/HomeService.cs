using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HangWeb.Models;
using System.Data;
using System.Data.SqlClient;

namespace HangWeb.Service
{
    public class HomeService
    {
        public List<Questions> getAllQuestionsByIDUserAndDifficulty(int IDUser, int difficulty)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");
            List<Questions> questions = new List<Questions>();
            string cmdString = "SELECT IDQuestion,Name,Question,Answer FROM msQuestion a JOIN msUser b ON a.QuestionBy= b.IDUser WHERE Status = 1 AND Difficulty = "+difficulty+" AND QuestionBy !=" + IDUser+" AND AnsweredBy !="+IDUser ;

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader QuestionsDR;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlConnection.Open();

            QuestionsDR = sqlCommand.ExecuteReader();

            if (QuestionsDR.HasRows)
            {
                while (QuestionsDR.Read())
                {
                    questions.Add(new Questions() { IDQuestion=(int)QuestionsDR["IDQuestion"], NameQuestionBy=(string)QuestionsDR["Name"],
                        Question =(string)QuestionsDR["Question"], Answer=(string)QuestionsDR["Answer"]});
                }

            }


            QuestionsDR.Close();
            sqlCommand.Dispose();
            sqlConnection.Close();

            return questions;

        }

        public List<Questions> getAllQuestionsByDifficulty(int difficulty)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");
            List<Questions> questions = new List<Questions>();
            string cmdString = "SELECT IDQuestion,Name,Question,Answer FROM msQuestion a JOIN msUser b ON a.QuestionBy= b.IDUser WHERE Status = 1 AND Difficulty = " + difficulty;

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader QuestionsDR;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlConnection.Open();

            QuestionsDR = sqlCommand.ExecuteReader();

            if (QuestionsDR.HasRows)
            {
                while (QuestionsDR.Read())
                {
                    questions.Add(new Questions()
                    {
                        IDQuestion = (int)QuestionsDR["IDQuestion"],
                        NameQuestionBy = (string)QuestionsDR["Name"],
                        Question = (string)QuestionsDR["Question"],
                        Answer = (string)QuestionsDR["Answer"]
                    });
                }

            }


            QuestionsDR.Close();
            sqlCommand.Dispose();
            sqlConnection.Close();

            return questions;

        }
    }
}