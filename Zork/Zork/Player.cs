using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Player
    {
        private string _bio;
        public string Name { get; set; }
        public List<Inventory> InventoryList = new List<Inventory>();
        
        //Val 1,2,3
        public string Bio {
            get
            {
                return _bio;
            }
            private set
            {
                if (value == CharacterIs.Mimmi.ToString())
                {
                   _bio = "Mimmi, fruktad i orten! Känd för att alltid vara i tid";
                }
                else if (value == CharacterIs.Markus.ToString())
                {
                    _bio = "Markus delar plats med Mimmi";
                }
                else if (value == CharacterIs.Ahmad.ToString())
                {
                    _bio = "Ahmad är bäst";
                }
                else
                {
                    _bio = "default";
                }
            }
        }

        // Constructor
        public Player(CharacterIs player)
        {
            Bio = player.ToString();
        }
    }

    public enum CharacterIs
    {
        Mimmi,
        Markus,
        Ahmad
    }
}
