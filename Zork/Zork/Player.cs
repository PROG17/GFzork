using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Player
    {
        private string bio;

        public string Name { get; set; }


        //Val 1,2,3
        public string Bio {
            get
            {
                return bio;
            }
            private set
            {
                if (value == CharacterIs.Mimmi.ToString())
                {
                   bio = "Mimmi, fruktad i orten! Känd för att alltid vara i tid";
                }
                else if (value == CharacterIs.Markus.ToString())
                {
                    bio = "Markus delar plats med Mimmi";
                }
                else if (value == CharacterIs.Ahmad.ToString())
                {
                    bio = "Ahmad är bäst";
                }
                else
                {
                    bio = "default";
                }
            }
        }

        // Constructor
        public Player(CharacterIs player)
        {
            Bio = player.ToString();
        }


    }
}
