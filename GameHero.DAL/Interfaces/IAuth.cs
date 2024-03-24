using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.DAL.Inrefaces
{
    internal interface IAuth
    {
        string Username { get; set; }

        string Password { get; set; }

    }
}
