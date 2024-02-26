﻿using GameHero.Enums;
using GameHero.Interfaces;
using GameHero.Models;
using GameHero.Weapons;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameHero.Managers
{
    internal class GameManager
    {
        private HeroModel hero;
        private Dictionary<WeaponTypes, IWeapon> Weapons;

        public GameManager()
        {
            using (SqlConnection sqlConnection = new SqlConnection(""))
            {
                using SqlCommand cmd = sqlConnection.CreateCommand();
                //cmd.ExecuteReader();d
            }
            
            WeaponManager weaponManager = new WeaponManager();
            hero = new HeroModel();
            Weapons = hero.GetWeaponsList(); 
            NewGame();
            Running();
            GameOver();            
        }
        private void NewGame() 
        {
            if (hero != null) 
            {
                hero.HP = 100;
            }
        }

        private void Running() 
        {
            void Head()
            {
                Console.WriteLine("Очки здоровья: " + hero.HP + "\n");
                Console.WriteLine("Оружие в рюкзаке:");
                foreach (var weapons in Weapons)
                {
                    Console.WriteLine(weapons.Value.Name + " патроны: "+ weapons.Value.MagazineCapacity);
                }
                Console.WriteLine("Выбранное оружие: " + hero.GetCurrentWeapon().Name + "\n");
                Console.WriteLine(hero.GetCurrentWeapon().Image);
                Console.WriteLine("------------------------------------------");
            }
            string line = "";
            string mainMenu ="Меню \n" +
                            "1. Введите 'weapons' для выбора оружия \n" +
                            "2. Введите 'attack' для атаки оружием \n" +
                            "3. Введите 'exit' для выхода \n";

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
                        hero.ChangeWeapon(WeaponTypes.Hand);
                    }
                    if (weaponLine == "pistol")
                    {
                        hero.ChangeWeapon(WeaponTypes.Pistol);
                    }
                    weaponLine = "back";
                }
                while (weaponLine != "back");
            }

            void Attack()
            {
                if(hero != null) 
                {
                    hero.Attack();
                    Thread.Sleep(1000);
                }
               
            }

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
        }
        private void GameOver() 
        {
            Console.WriteLine("До свидания, спасибо за игру!");
            Thread.Sleep(1000);
        }
    }
}
