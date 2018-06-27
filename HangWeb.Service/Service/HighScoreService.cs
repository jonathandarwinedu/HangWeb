using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HangWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace HangWeb.Service.Service
{
    public class HighScoreService
    {
        public List<HighScore> getHighScoreList()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");
            List<HighScore> highScores = new List<HighScore>();

            string cmdString = "SELECT IDUser,Name,Point FROM MsUser ORDER BY POINT DESC LIMIT 10";

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
                    highScores.Add(new HighScore() { IDUser=(int)HighScoreDR["IDUser"], Name=(string)HighScoreDR["Name"], Point=(int)HighScoreDR["Point"] });
                }
            }

            HighScoreDR.Close();
            sqlCommand.Dispose();
            sqlConnection.Close();

            return highScores;
        }
    }
}