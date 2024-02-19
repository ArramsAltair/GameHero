using GameHero.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHero.Interfaces
{
    internal interface IUnit
    {
        public byte HP { get; set; }
        public abstract void Attack();
    }
}
