using GameHero.Enums;
using GameHero.Interfaces;

namespace GameHero.Weapons
{
    internal class PistolWeapon : Weapon, IWeapon, IFabric
    {

        public override string Name { get; set; } = "Пистолет";

        public WeaponTypes WeaponType { get; set; } = WeaponTypes.Pistol;

        public override int MagazineCapacity { get; set; } = 10;

        public AttackTypes AttackType { get; set; } = AttackTypes.Range;

        public override double FireSpeed { get; set; } = 1;

        public override double Damage { get; set; } = 5;

        public override string Image { get; set; } =" {+--^----------,--------,-----,--------^-, \n" +
                                                    " | |||||||||   `--------'     |          O  \n" +
                                                    " `+---------------------------^----------|  \n" +
                                                    "   `'\'_,---------,---------,--------------'\n" +
                                                    "     / XXXXXX /'|       /'                  \n" +
                                                    "    / XXXXXX /  `'\'    /'                  \n" +
                                                    "   / XXXXXX /`-------'                      \n" +
                                                    "  / XXXXXX /                                \n" +
                                                    " / XXXXXX /                                 \n" +
                                                    "(________(                                  \n" +
                                                    " `------'                                   \n";  




        public override void Attack()
        {
            if (MagazineCapacity > 0)
            {
                MagazineCapacity -= 1;

                Console.WriteLine("Выстрел " + Name);
                Console.WriteLine("Нанесен урон: " + Damage);
                Console.WriteLine("Осталось патронов в магазине: " + MagazineCapacity);
            }
            else
            {
                Console.WriteLine("Выстрел " + Name + " не удался!");
                Console.WriteLine("Нанесен урон: 0");
                Console.WriteLine("Осталось патронов в магазине: " + MagazineCapacity);
            }            
        }

        public IWeapon Create()
        {
            return new PistolWeapon();
        }
    }
}
