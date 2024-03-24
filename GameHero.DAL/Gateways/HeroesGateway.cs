using GameHero.DAL.Interfaces;
using GameHero.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.DAL.Gateways
{
    public class HeroesGateway : IDisposable
    {
        #region private
        /// <summary>
        /// Константа подключения к бд
        /// </summary>
        private const string _connectionString = "Data Source=ARRAMSNB\\MSSQLSERVER04; Integrated Security=SSPI; Initial Catalog=HeroesGame;";

        private bool _disposed;

        #endregion private

        #region dispose method

        private void Dispose(bool disposed)
        {
            if (_disposed)
            {
                return;
            }

            _disposed = disposed;

            //_sqlConnection?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion dispose method


        /// <summary>
        /// Реализация метода получения списка героев из базы данных
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public UserInfo GetUserHeroes(UserInfo userInfo) 
        {
            using (SqlConnection _sqlConnection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = _sqlConnection.CreateCommand())
                {
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

                    _sqlConnection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return null;
                        }
                        userInfo.heroesList.Clear();
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
    
        /// <summary>
        /// Реализация метода сохранения параметров героя
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public bool SaveUsersHero(IHeroModel hero) 
        {

            using (SqlConnection _sqlConnection = new SqlConnection(_connectionString)) 
            {
                using (SqlCommand cmd = _sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Heroes] SET [HeroHP] = @heroHP, [HeroLevel] = @heroLvl, [CurrentWeapon] = @heroCurrentWeapon, [HeroScore] = @heroScore WHERE [Heroes].[HeroId] = @heroId";
                    cmd.Parameters.AddWithValue("@heroId", hero.HeroId);
                    cmd.Parameters.AddWithValue("@heroHP", hero.HP);
                    cmd.Parameters.AddWithValue("@heroLvl", hero.HeroLevel);
                    cmd.Parameters.AddWithValue("@heroCurrentWeapon", hero.CurrentWeapon);
                    cmd.Parameters.AddWithValue("@heroScore", hero.HeroScore);
                    
                    try
                    {
                        cmd.Connection.Open();
                    }
                    catch
                    {
                        return false;
                    }

                    return true;
                }
            }   
        }

    }
}
