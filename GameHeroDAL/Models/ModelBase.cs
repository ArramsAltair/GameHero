using GameHeroDAL.Inrefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHeroDAL.Models
{
    internal abstract class ModelBase : IModels
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
