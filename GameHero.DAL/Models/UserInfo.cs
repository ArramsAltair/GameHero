using GameHero.DAL.Inrefaces;
using GameHero.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.DAL.Models
{
    public class UserInfo 
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserRole { get; set; }

        public IHeroModel CurrentHero { get; set; }

        public List<HeroModel> heroesList { get; set; }

        public UserInfo()
        {
            heroesList = new List<HeroModel>();
        }

    }
}
