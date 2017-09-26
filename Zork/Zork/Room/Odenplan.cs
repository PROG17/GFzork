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
                Bio = "You find yourself outside the metro station"
                      /*"If [inspect]{To the left you find the bus 73 going for School, on the right side you find" +
                      "bus 69 which also takes you to school but 5 min faster" +
                      "if[phone is in items]{Check which bus gets you there faster}" +
                      "if go to bus 73{you will be late}" +
                      "if go to bus 69{you will be on time}"*/;
            }
            else if (character == CharacterIs.Mimmi)
            {
                Bio = "You only drive by, no need for stops";
            }
            else if (character == CharacterIs.Markus)
            {
                Bio = "You arrive at Odenplan, you make your way up to the bus terminal."
                      /*"If [inspect]{To the left you find the bus 73 going for School, on the right side you find" +
                      "bus 69 which also takes you to school but 5 min faster" +
                      "if Walk{-why take the bus when you can enjoy nature and exercise at the same time?} Gets hit by a bus and dies"*/;

            }

        }
        
    }
}
