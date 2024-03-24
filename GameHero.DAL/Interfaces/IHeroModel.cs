using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.DAL.Interfaces
{
    public interface IHeroModel
    {
        int HeroId { get; set; }

        string HeroName { get; set; }

        string HeroType { get; set; }

        double HP { get; set; }

        int HeroLevel { get; set; }

        int HeroScore { get; set; }

        string CurrentWeapon {get; set; }
    }
}
