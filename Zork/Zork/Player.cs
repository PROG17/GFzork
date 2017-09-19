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
            set
            {
                if (value=="mimmi")
                {
                   bio= "Mimmi, fruktad i orten! Känd för att alltid vara i tid";
                }
                else if (value == "markus")
                {
                    bio = "Marcus är delar plats med Mimmi";
                }
                else if (value == "ahmad")
                {
                    bio = "Ahmad är bäst";
                }
                else
                {
                    bio = "default";
                }
            }
        }

    }
}
