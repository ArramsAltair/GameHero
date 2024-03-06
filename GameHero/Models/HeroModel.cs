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
    internal class HeroModel : IUnit
    {
        public double HP { get; set; }

        IWeapon currentWeapon { get; set; }

        public int CountWeapons{ get; set; }

        public double Score { get; set; }


        Dictionary<WeaponTypes, IWeapon> Weapons = new Dictionary<WeaponTypes, IWeapon>();
        
        /// <summary>
        /// Свойство выборо текущего оружия
        /// </summary>
        public WeaponTypes WeaponTypes { get; set; } = WeaponTypes.Hand; 

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
            WeaponTypes = weaponTypes;

        }
        /// <summary>
        /// Получение информации о текущем оружии
        /// </summary>
        /// <returns></returns>
        public IWeapon GetCurrentWeapon() 
        {
            return currentWeapon = Weapons[WeaponTypes];
        }

        /// <summary>
        /// Атака текущим оружием
        /// </summary>
        public void Attack()
        {
            if (!Weapons.ContainsKey(WeaponTypes)) 
            {
                Console.WriteLine("Неизвестное оружие");
                return;
            }
            
            Weapons[WeaponTypes]?.Attack();
        }
    }
}
