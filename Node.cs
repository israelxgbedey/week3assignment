using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3assignement
{
    public class Node
    {
        public string Data { get; set; }
        public int MonsterHealth { get; set; }
        public int NumberOfAttacks { get; set; }
        public int PlayerHealth { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }
    }
}
