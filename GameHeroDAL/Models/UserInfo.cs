using GameHeroDAL.Inrefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHeroDAL.Models
{
    internal class UserInfo : ModelBase, IUser
    {
        public string UserName { get; set; }

        public int Score { get; set; }

    }
}
