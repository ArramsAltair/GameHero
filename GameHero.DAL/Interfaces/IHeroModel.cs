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

        int HeroLevel { get; set; }

        int HeroType { get; set; }
        
        int HP { get; set; }

        string CurrentWeapon {get; set; }
    }
}
