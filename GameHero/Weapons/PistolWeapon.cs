using GameHero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.Weapons
{
    internal class PistolWeapon : Weapon, IWeapon, IFabric
    {
        public override string Name => "Pistol";
        public override int MagazineCapacity => 10;

        public override double FireSpeed => 1;

        public override double Damage => 5;

        public override void Attack()
        {
            Console.WriteLine("Выстрел пистолета");
        }
        public IWeapon Create()
        {
            return new PistolWeapon();
        }
    }
}
