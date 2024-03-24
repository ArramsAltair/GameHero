using GameHero.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.DAL.Interfaces
{
    public interface IUserHeroesInfo
    {
        public HeroModel CurrentHero { get; set; }

        public List<HeroModel> heroesList { get; set;}
    }
}
