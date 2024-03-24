using GameHero.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.Interfaces
{
    internal interface IWeapon
    {
        public string Name { get; }

        public WeaponTypes WeaponType { get; }

        public int MagazineCapacity { get; }

        public AttackTypes AttackType { get; }

        public double FireSpeed { get; }

        public double Damage { get; }

        public string Image { get; }

        public abstract void Attack();
    }
}
