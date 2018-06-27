using HangWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace HangWeb.Service
{
    
    public class HighScoreService
    {
        public List<HighScore> getHighScoreList()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");
            List<HighScore> highScores = new List<HighScore>();

            string cmdString = "SELECT TOP 10 IDUser,Name,Point FROM MsUser WHERE Role <> 'Admin' ORDER BY Point DESC";

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader HighScoreDR;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlConnection.Open();

            HighScoreDR = sqlCommand.ExecuteReader();

            if (HighScoreDR.HasRows)
            {
                while (HighScoreDR.Read())
                {
                    highScores.Add(new HighScore() { IDUser = (int)HighScoreDR["IDUser"], Name = (string)HighScoreDR["Name"], Point = (int)HighScoreDR["Point"] });
                }
            }

            HighScoreDR.Close();
            sqlCommand.Dispose();
            sqlConnection.Close();

            return highScores;
        }
    }
}