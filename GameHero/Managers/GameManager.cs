using GameHero.Interfaces;
using GameHero.Models;
using GameHero.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.Managers
{
    internal class GameManager
    {
        public GameManager() 
        {
            WeaponManager weaponManager = new WeaponManager();
        }        
    }
}
