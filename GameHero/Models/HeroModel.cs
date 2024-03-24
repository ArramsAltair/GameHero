using GameHero.DAL.Interfaces;
using GameHero.Enums;
using GameHero.Interfaces;
using GameHero.Managers;
using GameHero.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.Models
{
    internal class HeroModel : IUnit, IHeroModel
    {
        public int HeroId { get; set; }

        public string HeroName { get; set; }

        public string HeroType { get; set; }

        public int HeroLevel { get; set; }

        public double HP { get; set; }

        IWeapon _currentWeapon { get; set; }

        public string CurrentWeapon { get; set; }

        public int CountWeapons{ get; set; }

        public int HeroScore { get; set; }


        Dictionary<WeaponTypes, IWeapon> Weapons = new Dictionary<WeaponTypes, IWeapon>();
        
        /// <summary>
        /// Свойство выборо текущего оружия
        /// </summary>
        public WeaponTypes DeffaultWeaponType { get; set; } = WeaponTypes.Hand;


        /// <summary>
        /// Модель героя по-умолчанию
        /// </summary>
        public HeroModel() 
        {
            Weapons.Add(WeaponTypes.Hand, new HandWeapon());
            Weapons.Add(WeaponTypes.Pistol, new PistolWeapon());
        }

        /// <summary>
        /// Метод полуения списка оружия героя
        /// </summary>
        /// <returns></returns>
        public Dictionary<WeaponTypes, IWeapon> GetWeaponsList() 
        {
            return Weapons;
        }
        
        /// <summary>
        /// Метод добавления герою оружия с параметром типа оружия
        /// </summary>
        /// <param name="weaponTypes"></param>
        public void AddWeapon(WeaponTypes weaponTypes)
        {
            if (WeaponManager.GetWeapon(weaponTypes) == null)
            {
                return;
            }
            Weapons.Add(weaponTypes, WeaponManager.GetWeapon(weaponTypes)); //Ошибка null из GetWeapon
        }

        /// <summary>
        /// Назначение оружия по-умолчанию
        /// </summary>
        /// <param name="weaponTypes"></param>
        public void ChangeWeapon(WeaponTypes weaponTypes) 
        {
            CurrentWeapon = weaponTypes.ToString();
            DeffaultWeaponType = weaponTypes;

        }
        /// <summary>
        /// Получение информации о текущем оружии
        /// </summary>
        /// <returns></returns>
        public IWeapon GetCurrentWeapon() 
        {
            return _currentWeapon = Weapons[DeffaultWeaponType];
        }

        /// <summary>
        /// Атака текущим оружием
        /// </summary>
        public void Attack()
        {
            if (!Weapons.ContainsKey(DeffaultWeaponType)) 
            {
                Console.WriteLine("Неизвестное оружие");
                return;
            }
            
            Weapons[DeffaultWeaponType]?.Attack();
        }
    }
}
