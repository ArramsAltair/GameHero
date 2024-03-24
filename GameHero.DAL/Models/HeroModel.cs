using GameHero.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.DAL.Models
{
    public class HeroModel : IHeroModel
    {
        public int HeroId { get; set; }

        public string HeroName { get; set; }

        public string HeroType { get; set; }

        public double HP { get; set; }

        public int HeroLevel { get; set; }

        public string CurrentWeapon { get; set; }

        public string CurrentArmor { get; set; }

        public int HeroScore { get; set; }
        
    }
}
