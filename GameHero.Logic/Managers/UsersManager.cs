
using GameHero.DAL;
using GameHero.DAL.Inrefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.Logic.Managers
{
    public class UsersManager
    {
        /// <summary>
        /// Метод аутентификации пользователя
        /// </summary>
        public IUserInfo UserAuth()
        {
            string username = "";
            string password = "";
            bool auth = false;

            while (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || !auth)
            {
                Console.WriteLine("Для входа в игру требуется авторизоваться");
                if (string.IsNullOrEmpty(username))
                {
                    Console.WriteLine("Введите логин");
                    username = Console.ReadLine();
                }

                if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Введите пароль");
                    password = Console.ReadLine();
                }

                auth = new UsersGateway().IsAuth(username, password);

                if (!auth)
                {
                    Console.WriteLine("Неправильный логин или пароль");
                    Console.WriteLine("Вы желаете выйти? y/n");
                    username = "";
                    password = "";
                    if(Console.ReadLine() == "y")
                    {
                        return null;
                    }
                    
                }
                Console.Clear();
            }
            //Console.Clear();

            return new UsersGateway().GetUserByUserName(username);
        }
    }
}
