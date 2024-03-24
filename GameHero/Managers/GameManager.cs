using GameHero.Enums;
using GameHero.Interfaces;
using GameHero.Models;
using GameHero.Weapons;
using GameHero.DAL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameHero.Logic.Managers;
using GameHero.DAL.Inrefaces;
using System.Reflection.PortableExecutable;
using GameHero.DAL.Models;
using GameHero.DAL.Interfaces;

namespace GameHero.Managers
{
    internal class GameManager
    {
        private Models.HeroModel _hero;

        private Dictionary<WeaponTypes, IWeapon> _weapons;

        private UserInfo _userInfo;

        public GameManager()
        {            
        }

        /// <summary>
        /// Реализация метода running
        /// </summary>
        public void Running()        
        {
            _userInfo = new UsersManager().UserAuth();
            if (_userInfo is null)
            {
                return;
            }

            Console.WriteLine("Добро пожаловать в игру ГЕРОИ, " + _userInfo.UserName + "!");

            Load();           
            Game();
            GameOver();
        }

        /// <summary>
        /// Реализация метода загрузки параметров героя
        /// </summary>
        public void Load() 
        {
            
            if (_hero == null) 
            {
                _hero = new Models.HeroModel();

                _userInfo = new UsersManager().UserHeroes(_userInfo);

                if (_userInfo.heroesList.Count == 0)
                {
                    new HeroesManager().NewHero(_hero);
                }
            }

            _weapons = _hero.GetWeaponsList();
            
            _hero = (Models.HeroModel)new HeroesManager().LoadHero(_hero, _userInfo.CurrentHero);
            
        }        


        /// <summary>
        /// Реализация метода основного процесса игры
        /// </summary>
        private void Game() 
        {
            #region fields

            string line = "";
            string mainMenu = $"Меню \n" +
                            "1. Введите 'weapons' для выбора оружия \n" +
                            "2. Введите 'attack' для атаки оружием \n" +
                            "3. Введите 'exit' для выхода \n";

            #endregion fields

            #region local methods

            void Head()
            {
                string subSpace = $"__________________________";

                Console.WriteLine($"Герой:          {_hero.HeroName}    ");
                Console.WriteLine($"Уровень:        {_hero.HeroLevel}   ");
                Console.WriteLine($"Очки здоровья:  {_hero.HP}          ");
                Console.WriteLine(subSpace);
                Console.WriteLine("Оружие в рюкзаке:");
                foreach (var weapons in _weapons)
                {
                    Console.WriteLine($"{weapons.Value.Name}");
                    
                }
                Console.WriteLine(subSpace);
                Console.WriteLine("Выбранное оружие: " + _hero.GetCurrentWeapon().Name);

                if (_hero.GetCurrentWeapon().AttackType == AttackTypes.Range)
                {
                    Console.WriteLine($"Патроны: {_hero.GetCurrentWeapon().MagazineCapacity}\n");
                }

                Console.WriteLine(_hero.GetCurrentWeapon().Image);
                Console.WriteLine(subSpace);
            }

            void WeaponMenu()
            {
                Console.Clear();
                string weaponLine = "";
                string weaponChange = "Оружие\n" +
                                    "1. Рука 'hand'\n" +
                                    "2. Пистолет 'pistol'\n" +
                                    "3. Вернуться 'back'\n";
                do
                {
                    Head();
                    Console.WriteLine(weaponChange);
                    weaponLine = Console.ReadLine();

                    if (weaponLine == "hand")
                    {
                        _hero.ChangeWeapon(WeaponTypes.Hand);
                    }
                    if (weaponLine == "pistol")
                    {
                        _hero.ChangeWeapon(WeaponTypes.Pistol);
                    }
                    weaponLine = "back";
                }
                while (weaponLine != "back");
            }

            void Attack()
            {
 
                _hero.Attack();
                _hero.HP += 5;
                Thread.Sleep(1000);
                
               
            }

            void ChangeHero()
            {
                Console.Clear();
                Console.WriteLine("Желаете выбрать другого героя? y/n");

                if (Console.ReadLine() == "y")
                {
                    Save();
                    _userInfo = new UsersManager().UserHeroes(_userInfo);
                    this.Load();
                    this.Game();
                }
            }

            #endregion local methods

            do
            {
                Head();
                Console.WriteLine(mainMenu);

                line = Console.ReadLine();

                switch (line)
                {
                    case "weapons":
                        WeaponMenu();
                        break;

                    case "attack":
                        Attack();
                        break;
                }
                Console.Clear();
            }
            while (line != "exit");

            ChangeHero();
        }

        /// <summary>
        /// Реализация метода вызова диалога окончания игры
        /// </summary>
        private void GameOver()
        {
            Save();
            Console.Clear();
            Console.WriteLine("До свидания, спасибо за игру!");
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Реализация метода вызова диалога сохранения данных игрока
        /// </summary>
        private void Save() 
        {
            Console.Clear();
            Console.WriteLine("Желаете сохранить данные? y/n");
            if (Console.ReadLine() == "y")
            {
                while (!new HeroesManager().SaveHero(_hero)) 
                {
                    Console.Clear();
                    Console.WriteLine("Не удалось сохранить данные, повторить? y/n");
                    if (Console.ReadLine() != "y")
                    {
                        Thread.Sleep(1000);
                        return;
                    }
                }
                Console.WriteLine("Данные сохранены!");
                Thread.Sleep(1000);
            }
            
        }
    }
}
