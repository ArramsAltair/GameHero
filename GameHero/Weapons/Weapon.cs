using GameHero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.Weapons
{
    internal abstract class Weapon
    {
        public abstract string Name { get; }
        public abstract int MagazineCapacity { get; }
        public abstract double FireSpeed { get; }
        public abstract double Damage { get; }
        public abstract void Attack();
       
    }
}
