using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class Player
    {
        private readonly string name;
        public int Point { get; set; }

        public Player(string name)
        {
            this.name = name;
            this.Point = 0;
        }
    }
}
