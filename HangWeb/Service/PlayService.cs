using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HangWeb.Models;
using HangWeb.Service;
using System.Data.SqlClient;
using System.Data;

namespace HangWeb.Service
{
    public class PlayService
    {
        public Questions getQuestionByIDQuestion(int IDQuestion)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");
            Questions question = new Questions();
            string cmdString = "SELECT Name,Question,Answer,Difficulty FROM msQuestion a JOIN msUser b ON a.QuestionBy = b.IDUser WHERE IDQuestion="+IDQuestion;

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader QuestionDR;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlConnection.Open();

            QuestionDR = sqlCommand.ExecuteReader();

            if (QuestionDR.HasRows)
            {
                while (QuestionDR.Read())
                {
                    question.NameQuestionBy = (string)QuestionDR["Name"];
                    question.Question = (string)QuestionDR["Question"];
                    question.Answer = (string)QuestionDR["Answer"];
                    question.Difficulty = (int)QuestionDR["Difficulty"];
                }

            }
            QuestionDR.Close();
            sqlCommand.Dispose();
            sqlConnection.Close();

            return question;

        }

        public bool UpdateQuestion(Questions question)
        {                        
            SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");
            string cmdString = "UPDATE msQuestion SET Status=" + question.Status + ",AnsweredBy=" + question.AnsweredBy + " WHERE IDQuestion="+question.IDQuestion;            
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader QuestionDR;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlConnection.Open();

            try
            {
                QuestionDR = sqlCommand.ExecuteReader();                

                QuestionDR.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();

                return true;
            }
            catch(Exception ex)
            {                
                return false;
            }
            
        }        

        public bool UpdateUser(int IDUser, int point)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");
            string cmdString = "UPDATE msUser SET Point=" + point + " WHERE IDUser=" + IDUser;
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader QuestionDR;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlConnection.Open();

            try
            {
                QuestionDR = sqlCommand.ExecuteReader();

                QuestionDR.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}