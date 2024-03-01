using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHeroDAL.Inrefaces
{
    internal interface IUser
    {
        string UserName { get; set; }

        int Score { get; set; }

    }
}
