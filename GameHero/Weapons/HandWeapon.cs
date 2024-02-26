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
        public override string Name { get; set; } = "Рука";

        public override int MagazineCapacity { get; set; } = 1;

        public override double FireSpeed { get; set; } = 1;

        public override double Damage { get; set; } = .5f;

        public override string Image { get; set; } =    "    _______  \n" +
                                                        "---'   ____) \n" +
                                                        "      (_____)\n" +
                                                        "      (_____)\n" +
                                                        "      (____) \n" +
                                                        "---.__(___)  \n";


        public override void Attack()
        {
            Console.WriteLine("Удар "+ Name);
            Console.WriteLine("Нанесен урон: " + Damage);
        }

        public IWeapon Create()
        {
            return new HandWeapon();
        }
    }
}
