using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Odenplan:Room
    {
        public Odenplan(CharacterIs character)
        {
            Name = "Odenplan station";

            if (character == CharacterIs.Ahmad)
            {
                Bio = "You find yourself outside the metro station" +
                      "If [inspect]{To the left you find the bus 73 going for School, on the right side you find" +
                      "bus 69 which also takes you to school but 5 min faster" +
                      "if[phone is in inventory]{Check which bus gets you there faster}" +
                      "if go to bus 73{you will be late}" +
                      "if go to bus 69{you will be on time}";
            }
        }
        
    }
}
