using GameHero.DAL.Inrefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.DAL.Models
{
    internal class UserInfo : IUserInfo
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserRole { get; set; }

        public int HeroId { get; set; }        

    }
}
