using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHeroDAL.Inrefaces
{
    internal interface IUserInfo
    {
        string UserId { get; set; }

        string UserName { get; set; }

        int Score { get; set; }

        double HelthPoint { get; set; }

    }
}
