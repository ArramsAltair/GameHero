using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.DAL.Inrefaces
{
    public interface IUserMainInfo
    {
        int UserId { get; set; }

        string UserName { get; set; }

        string UserRole { get; set; }

    }
}
