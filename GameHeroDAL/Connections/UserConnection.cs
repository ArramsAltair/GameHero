using GameHeroDAL.Inrefaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameHeroDAL.Connections
{
    public class UserConnection
    {
        SqlConnection sqlConnection;
        public bool Connection()
        {
            using (sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = "Data Source=ARRAMSNB\\MSSQLSERVER04; Integrated Security=SSPI; Initial Catalog=HeroesGame;";
                try{
                    sqlConnection.Open();
                }catch (Exception ex) 
                {
                    Console.WriteLine("Invalid connection!");
                    return false;
                }  
            }
            return true;
            //Console.WriteLine("Соединение с базой успешно");
        }

        public void GetUsers() 
        {
            if(Connection())
            //using (sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = "Data Source=ARRAMSNB\\MSSQLSERVER04; Integrated Security=SSPI; Initial Catalog=HeroesGame;";
                sqlConnection.Open();

                using (SqlCommand cmd = sqlConnection.CreateCommand()) 
                {
                    cmd.ExecuteReader();
                    cmd.CommandText = "SELECT * FROM Users";
                    
                    
                    using (SqlDataReader reader = cmd.ExecuteReader()) 
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",reader[0], reader[1], reader[2], reader[3]));
                        }
                    }
                }   
            }
        }

        public bool IsAuth(string username, string password) 
        {
            if (Connection())
            //using (sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = "Data Source=ARRAMSNB\\MSSQLSERVER04; Integrated Security=SSPI; Initial Catalog=HeroesGame;";
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Login = @username AND Password = @password";
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else 
            {
                return false; 
            }
        }
    }
}
