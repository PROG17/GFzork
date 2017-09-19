using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Room
    {
        public string Home { get; set; }
        public string Bus { get; set; }
        public string School { get; set; }
        public string Odenplan { get; set; }
        public string Cab { get; set; }
        public string Train { get; set; }
        Inventory inventory = new Inventory();

    }
}
