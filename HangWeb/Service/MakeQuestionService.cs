using HangWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HangWeb.Service
{
    public class MakeQuestionService
    {
        public bool InsertQuestion(Questions questions)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");            
            // ANSWERED BY MASIH NEMBAK PAKE ID QUESTIONBY, NANTI DICARI CARANYA
            string cmdString = "INSERT INTO msQuestion(QuestionBy,Question,Answer,Status,AnsweredBy) VALUES("+questions.QuestionBy+", '"+questions.Question+"', '"+questions.Answer+"', 0,"+questions.QuestionBy+")";             
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader MakeQuestionDR;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlConnection.Open();

            try
            {
                MakeQuestionDR = sqlCommand.ExecuteReader();
                MakeQuestionDR.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                return false;
            }
                        
            return true;                       
        }
    }
}