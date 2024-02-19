using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.Interfaces
{
    internal interface IFabric
    {
        public abstract IWeapon Create();
    }
}
