using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HangWeb.Models;
using System.Data.SqlClient;
using System.Data;
using HangWeb.Models;

namespace HangWeb.Service
{
    public class UserService
    {
        public User getLogIn(UserLogIn userLogIn)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");
            User user = new User();
            string cmdString = "SELECT IDUser,Name,Role,Point FROM msUser WHERE Username='"+ userLogIn.Username + "' AND Password='"+ userLogIn.Password + "'";

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader LogInDR;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlConnection.Open();

            LogInDR = sqlCommand.ExecuteReader();

            if (LogInDR.HasRows)
            {
                while (LogInDR.Read())
                {
                    user.IDUser = (int)LogInDR["IDUser"];
                    user.Name = (string)LogInDR["Name"];
                    user.Role = (string)LogInDR["Role"];
                    user.Point = (int)LogInDR["Point"];
                    LogInDR.Close();
                    sqlCommand.Dispose();
                    sqlConnection.Close();

                    return user;
                }
                
            }
            
            
            LogInDR.Close();
            sqlCommand.Dispose();
            sqlConnection.Close();

            return user;

        }

        public bool InsertRegister(User user)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");            
            string cmdString = "INSERT INTO msUser(Username,Password,Name,Gender,Point,Role) VALUES('"+user.Username+"', '"+user.Password+"', '"+user.Name+"', '"+user.Gender+"', 0, 'User')";

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader RegisterDR;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlConnection.Open();

            try
            {
                RegisterDR = sqlCommand.ExecuteReader();
                RegisterDR.Close();
                sqlCommand.Dispose();
                sqlConnection.Close();

            }
            catch(Exception Ex)
            {                
                return false;
            }
                        
            return true;
        }

        public List<User> getAllUser()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HangWeb;Data Source=DESKTOP-MLI7UBI");
            List<User> user = new List<User>();
            string cmdString = "SELECT Username FROM msUser";

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader UserDR;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlConnection.Open();

            UserDR = sqlCommand.ExecuteReader();

            if (UserDR.HasRows)
            {
                while (UserDR.Read())
                {
                    user.Add(new User() { Username = (string)UserDR["Username"] });
                                        
                }

            }


            UserDR.Close();
            sqlCommand.Dispose();
            sqlConnection.Close();

            return user;
        }
        
    }
}