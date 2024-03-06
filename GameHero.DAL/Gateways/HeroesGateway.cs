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
        /// Метод получения и вывод всех героев из бд
        /// </summary>
        public void GetHeroes()
        {
            if (!Connection())
            {
                return;
            }

            using (SqlCommand cmd = _sqlConnection.CreateCommand())
            {
                cmd.ExecuteReader();
                cmd.CommandText = "SELECT * FROM Heroes";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(string.Format("{0} \t | {1} \t | {2} \t | {3}", reader[0], reader[1], reader[2], reader[3]));
                    }
                }
            }

        }
        
    }
}
