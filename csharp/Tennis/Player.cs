using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    class Player
    {
        private readonly string name;
        private readonly int point;

        public Player(string name, int point)
        {
            this.name = name;
            this.point = point;
        }
    }
}
