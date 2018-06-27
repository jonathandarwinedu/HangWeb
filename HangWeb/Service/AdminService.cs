using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HangWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace HangWeb.Service
{
    public class AdminService
    {
        public List<ApprovingQuestion> getAllNotAprrovedQuestions()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");
            List<ApprovingQuestion> questions = new List<ApprovingQuestion>();

            string cmdString = "SELECT IDQuestion,Question, Answer, Name FROM msQuestion a JOIN msUser b ON a.QuestionBy = b.IDUser WHERE Status = 0";

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader ApprovedQuestionsDR;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlConnection.Open();

            ApprovedQuestionsDR = sqlCommand.ExecuteReader();

            if (ApprovedQuestionsDR.HasRows)
            {
                while (ApprovedQuestionsDR.Read())
                {
                    questions.Add(new ApprovingQuestion() { IDQuestion=(int)ApprovedQuestionsDR["IDQuestion"],Question=(string)ApprovedQuestionsDR["Question"],Answer=(string)ApprovedQuestionsDR["Answer"], QuestionBy=(string)ApprovedQuestionsDR["Name"]});
                }
            }

            ApprovedQuestionsDR.Close();
            sqlCommand.Dispose();
            sqlConnection.Close();

            return questions;
        }

        public bool UpdateQuestion(int IDQuestion, int level,int status)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");            

            string cmdString = "UPDATE msQuestion SET Difficulty="+level+", Status="+status+" WHERE IDQuestion="+IDQuestion;

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader UpdateQuestion;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlConnection.Open();
            
            try
            {
                UpdateQuestion = sqlCommand.ExecuteReader();
                UpdateQuestion.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)            
            {                
                return false;
            }
            
            return true;
        }
    }
}