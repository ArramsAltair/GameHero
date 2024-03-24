
using GameHero.DAL;
using GameHero.DAL.Gateways;
using GameHero.DAL.Inrefaces;
using GameHero.DAL.Interfaces;
using GameHero.DAL.Models;
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
        public UserInfo UserAuth()
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

            return new UsersGateway().GetUser(username);
            //return new UsersGateway().GetUserInfo(new UsersGateway().GetUser(username));
        }


        /// <summary>
        /// Реализация метода выбора героя из списка имеющихся
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public UserInfo UserHeroes(UserInfo userInfo) 
        {
            if(userInfo is null) 
            {
                return null;
            }

            bool heroIsSet = false;

            string change = "";

            userInfo = new HeroesGateway().GetUserHeroes(userInfo);

            while (!heroIsSet) 
            {
                Console.Clear();
                if (userInfo.heroesList.Count == 0) 
                {
                    Console.WriteLine("Список героев пуст.");
                    Console.WriteLine("Желаете создать нового героя? y/n");
                    if (Console.ReadLine() == "y")
                    {
                        return null;
                    }
                }
                else
                {
                    //if (string.IsNullOrEmpty(change))
                    //{
                        Console.WriteLine("Выберите одного из ваших героев");
                        for (int i = 0; i < userInfo.heroesList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}.{userInfo.heroesList[i].HeroName} Уровень: {userInfo.heroesList[i].HeroLevel}");
                        }

                        change = Console.ReadLine();
                   // }
                    //else
                    //{
                        try
                        {
                            if (!string.IsNullOrEmpty(change) && Convert.ToInt16(change) - 1 < userInfo.heroesList.Count && Convert.ToInt16(change) > 0)
                            {
                                userInfo.CurrentHero = userInfo.heroesList[Convert.ToInt16(change) - 1];
                                heroIsSet = true;
                                change = "";
                                break;
                            }
                        }
                        catch (Exception e)
                        {

                        }
                        
                    //}
                }               
            }
            Console.Clear();
            return userInfo;
        }
    }
}
