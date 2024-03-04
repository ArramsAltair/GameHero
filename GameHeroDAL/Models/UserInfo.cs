using GameHeroDAL.Inrefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHeroDAL.Models
{
    internal class UserInfo : ModelBase, IUserInfo
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public int Score { get; set; }

        public double HelthPoint { get; set; }
        

        public UserInfo GetUserInfo()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = UserId;

            return userInfo;
        }

    }
}
