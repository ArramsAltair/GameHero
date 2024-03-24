using GameHero.Enums;
using GameHero.Interfaces;
using GameHero.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.Managers
{
    internal class WeaponManager
    {
        HandWeapon hand;
        PistolWeapon pistol;

        public static IWeapon GetWeapon(WeaponTypes weaponTypes) 
        {
            switch (weaponTypes) 
            {
                case WeaponTypes.Hand:
                    return new HandWeapon();
                    
                case WeaponTypes.Pistol: 
                    return new HandWeapon();
                    
                default: return null;
            }
        }
    }
}
