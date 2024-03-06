using GameHero.DAL.Inrefaces;
using GameHero.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameHero.DAL

{
    public class UsersGateway : IDisposable
    {
        private bool _disposed;
        private SqlConnection _sqlConnection;

        /// <summary>
        /// Метод подключения к бд
        /// </summary>
        /// <returns></returns>
        public bool Connection()
        {
            if (_sqlConnection?.State == System.Data.ConnectionState.Open)
            {
                return true;
            }

            _sqlConnection = new SqlConnection();
            _sqlConnection.ConnectionString = "Data Source=ARRAMSNB\\MSSQLSERVER04; Integrated Security=SSPI; Initial Catalog=HeroesGame;";

            try
            {
                _sqlConnection.Open();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid connection!");
                return false;
            }

            //Console.WriteLine("Соединение с базой успешно");
        }

        private void Dispose(bool disposed)
        {
            if (_disposed)
            {
                return;
            }

            _disposed = disposed;

            _sqlConnection?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Метод получения и вывод всех пользователей из бд
        /// </summary>
        public void GetUsers()
        {
            if (!Connection())
            {
                return;
            }

            using (SqlCommand cmd = _sqlConnection.CreateCommand())
            {
                cmd.ExecuteReader();
                cmd.CommandText = "SELECT * FROM Users";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(string.Format("{0} \t | {1} \t | {2} \t | {3}", reader[0], reader[1], reader[2], reader[3]));
                    }
                }
            }

        }

        /// <summary>
        /// Метод проверки авторизируемого пользователя на существование в базе
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsAuth(string username, string password)
        {
            if (!Connection())
            {
                return false;
            }

            using (SqlCommand cmd = _sqlConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
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

        /// <summary>
        /// Метод получения информации о пользователе
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private UserInfo GetUser(string username) 
        {
            UserInfo result = new ();

            using (SqlCommand cmdUsers = _sqlConnection.CreateCommand())
            {
                cmdUsers.CommandText = "SELECT [Id],[Username],[RoleId] FROM Users WHERE Username = @username";
                cmdUsers.Parameters.AddWithValue("username", username);

                using (SqlDataReader readerUsers = cmdUsers.ExecuteReader())
                {
                    if (!readerUsers.HasRows)
                    {
                        return result;
                    }

                    while (readerUsers.Read())
                    {
                        result.UserId   = (int)readerUsers[0];
                        result.UserName = readerUsers[1]?.ToString() ?? "";
                        result.UserRole = readerUsers[2]?.ToString() ?? "";
                    }
                    readerUsers.Close();
                }
            }
            return result; 
        }

        private int GetUserHeroId(int userId) 
        {   
            int userHeroId = -1;
            using (SqlCommand cmd = _sqlConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM UserHeroes WHERE User = @userid";
                cmd.Parameters.AddWithValue("userid", userId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        return -1;
                    }
                    while (reader.Read())
                    {
                        userHeroId = (int)reader[2];
                    }
                    reader.Close();
                }
            }
            return userHeroId;
        }

        /// <summary>
        /// method
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public IUserInfo GetUserByUserName(string username)
        {
            if (username == null)
            {
                return null;
            }
            if (!Connection())
            {
                return null;
            }
            
            UserInfo userInfo = GetUser(username);

            if (userInfo.UserId == -1) 
            {
                return null;
            }
            userInfo.HeroId = GetUserHeroId(userInfo.UserId);

            return userInfo;
        }
    }
}
