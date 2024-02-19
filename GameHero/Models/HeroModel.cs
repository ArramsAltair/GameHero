using GameHero.Enums;
using GameHero.Interfaces;
using GameHero.Managers;
using GameHero.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.Models
{
    internal class HeroModel : IUnit
    {
        public byte HP { get; set; }

        public Weapon CurrectWeapon { get; set; }

        Dictionary<WeaponTypes, IWeapon> Weapons = new Dictionary<WeaponTypes, IWeapon>();
        
        /// <summary>
        /// Свойство выборо текущего оружия
        /// </summary>
        public WeaponTypes WeaponTypes { get; set; } = WeaponTypes.Hand; 


        public HeroModel() 
        {
            Weapons.Add(WeaponTypes.Hand, new HandWeapon());
            Weapons.Add(WeaponTypes.Pistol, new PistolWeapon());
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

        public void ChangeWeapon(WeaponTypes weaponTypes) 
        {
            WeaponTypes = weaponTypes;
        }


        public void Attack()
        {
            if (!Weapons.ContainsKey(WeaponTypes)) 
            {
                Console.WriteLine("Неизвестное оружие");
                return;
            }
            Weapons[WeaponTypes]?.Attack();
        }


        public string GetCurrectWeaponName() 
        {
            return CurrectWeapon.Name; 
        }
    }
}
