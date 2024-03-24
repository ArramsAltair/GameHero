using GameHero.DAL.Gateways;
using GameHero.DAL.Interfaces;
using GameHero.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.Logic.Managers
{
    public class HeroesManager
    {
        public HeroesManager() 
        {
            
        }
        public IHeroModel LoadHero(IHeroModel newHeroModel, IHeroModel loadedHeroModel)
        {
            if (newHeroModel == null)
            {
                return null;
            }
            newHeroModel.HeroId = loadedHeroModel.HeroId;
            newHeroModel.HeroName = loadedHeroModel.HeroName;
            newHeroModel.HeroType = loadedHeroModel.HeroType;
            newHeroModel.HP = loadedHeroModel.HP;
            newHeroModel.HeroLevel = loadedHeroModel.HeroLevel;
            newHeroModel.CurrentWeapon = loadedHeroModel.CurrentWeapon;
            newHeroModel.HeroScore = loadedHeroModel.HeroScore;
            return newHeroModel;
        }

        public void NewHero(IHeroModel heroModel)
        {

            SetHeroName();
            SetHeroType();
            //heroModel.HeroType = ;
            //DefaultHeroStates();

            //heroModel.HeroId = ;

            void SetHeroName() 
            {
                Console.Clear();

                string heroName = "";

                Console.WriteLine("Введите имя героя");
                heroName = Console.ReadLine();

                if (string.IsNullOrEmpty(heroName))
                {
                    SetHeroName();
                }
                else
                {
                    Console.WriteLine($"Выбранное вами имя героя: {heroName}\nВы уверены? y/n");

                    if (Console.ReadLine() == "y")
                    {
                        heroModel.HeroName = heroName;
                        return;
                    }

                    SetHeroName();
                }
            }

            void SetHeroType() 
            {
                
            }

            void DefaultHeroStates() 
            {
                // Очки здоровья в зависимости от расы
                heroModel.HP = 100;
                heroModel.HeroLevel = 0;
                heroModel.HeroScore = 0;
                // Стандартное оружие в зависимости от расы
                //heroModel.CurrentWeapon = ;
                // Стандартное снаряжение в зависимости от расы
                //heroModel.CurrentArmor = ;
            }
        }

        public bool SaveHero(IHeroModel hero) 
        {
            if (hero == null)
            {
                return false;
            }

            try 
            {
                if (new HeroesGateway().SaveUsersHero(hero))
                {
                    return true;
                }
                else
                { 
                    return false; 
                }
                
            }
            catch 
            { 
                return false;
            }
        }

    }
}
