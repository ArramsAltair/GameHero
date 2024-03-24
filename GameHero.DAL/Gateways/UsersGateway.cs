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

        #region private

        /// <summary>
        /// Константа подключения к бд
        /// </summary>
        private const string _connectionString = "Data Source=ARRAMSNB\\MSSQLSERVER04; Integrated Security=SSPI; Initial Catalog=HeroesGame;";

        private bool _disposed;

        #endregion

        private void Dispose(bool disposed)
        {
            if (_disposed)
            {
                return;
            }

            _disposed = disposed;

        }

        public void Dispose()
        {
            Dispose(true);
        }


        /// <summary>
        /// Метод проверки авторизируемого пользователя на существование в базе
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsAuth(string username, string password)
        {
            using (SqlConnection _sqlConnection = new SqlConnection(_connectionString)) 
            {
                using (SqlCommand cmd = _sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT [Username],[Password] FROM Users WHERE Username = @username AND Password = @password";
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);

                    try 
                    {
                        cmd.Connection.Open();
                    }
                    catch 
                    {
                        return false;
                    }
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
        }

        /// <summary>
        /// Метод получения информации о пользователе
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserInfo GetUser(string username) 
        {

            using (SqlConnection _sqlConnection = new SqlConnection(_connectionString))
            {
                UserInfo result = new();

                using (SqlCommand cmd = _sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT [UserId],[UserName],[RoleId] FROM Users WHERE Username = @username";
                    cmd.Parameters.AddWithValue("username", username);

                    try
                    {
                        cmd.Connection.Open();
                    }
                    catch
                    {
                        return null;
                    }

                    using (SqlDataReader readerUsers = cmd.ExecuteReader())
                    {
                        if (!readerUsers.HasRows)
                        {
                            return null;
                        }

                        while (readerUsers.Read())
                        {
                            result.UserId = (int)readerUsers[0];
                            result.UserName = readerUsers[1]?.ToString() ?? "";
                            result.UserRole = readerUsers[2]?.ToString() ?? "";
                        }
                        readerUsers.Close();
                        return result;
                    }
                }
            }
        }

        public UserInfo GetUserInfo(UserInfo userInfo) 
        {
            if(userInfo is null) 
            {
                return null;
            }
            using (SqlConnection _sqlConnection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = _sqlConnection.CreateCommand())
                {
                    //Перенести в HeroManager
                    cmd.CommandText = @"SELECT   h.[HeroId]
		                                    ,h.[HeroName]
		                                    ,h.[HeroType]
		                                    ,h.[HeroHP]
		                                    ,h.[HeroLevel]
		                                    ,h.[CurrentWeapon]
		                                    ,h.[CurrentArmor]
		                                    ,h.[HeroScore]
                                    FROM  [dbo].[Users] u
		                            JOIN [dbo].[Users.Heroes] uh on uh.[UserId] = u.[UserId]
		                            JOIN [dbo].[Heroes] h on h.[HeroId] = uh.[HeroId]
	                                WHERE u.[Username] = @username
	                                ORDER BY u.[Username]";
                    cmd.Parameters.AddWithValue("username", userInfo.UserName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return null;
                        }
                        while (reader.Read())
                        {
                            HeroModel model = new();
                            model.HeroId = reader.GetInt32(0);
                            model.HeroName = reader.GetString(1);
                            model.HeroType = reader.GetString(2);
                            model.HP = reader.GetDouble(3);
                            model.HeroLevel = reader.GetInt32(4);
                            model.CurrentWeapon = reader.GetString(5);
                            model.CurrentArmor = reader.GetString(6);
                            model.HeroScore = reader.GetInt32(7);
                            userInfo.heroesList.Add(model);
                        }
                        reader.Close();
                        return userInfo;
                    }
                }
            }
              
        }
    }
}
