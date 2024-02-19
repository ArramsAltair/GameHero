using GameHero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.Weapons
{
    internal class HandWeapon : Weapon, IFabric, IWeapon
    {
        public HandWeapon()
        {

        }
        public override string Name => "Рука";

        public override int MagazineCapacity => 1;

        public override double FireSpeed => 1;

        public override double Damage => .5f;

        public override void Attack()
        {
            Console.WriteLine("Удар рукой");
        }

        public IWeapon Create()
        {
            return new HandWeapon();
        }
    }
}
