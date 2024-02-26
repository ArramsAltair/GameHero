namespace GameHero.Weapons
{
    internal abstract class Weapon
    {
        public abstract string Name { get; set; }

        public abstract int MagazineCapacity { get; set; }

        public abstract double FireSpeed { get; set; }

        public abstract double Damage { get; set; }

        public abstract string Image { get; set; }

        public abstract void Attack();       
    }
}
