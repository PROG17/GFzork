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
        public CharacterIs Character { get; private set; }

        Inventory inventory = new Inventory();
        
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
            Character = player;
            Bio = player.ToString();
            CreateInventoryList(player);
        }

        private void CreateInventoryList(CharacterIs character)
        {
            switch (character)
            {
                case CharacterIs.Mimmi:
                    inventory.BusCard = false;
                    inventory.Coffe = false;
                    inventory.Food = false;
                    inventory.Keys = false;
                    inventory.SmartPhone = false;
                    inventory.Wallet = false;
                    break;
                case CharacterIs.Ahmad:
                    inventory.BusCard = false;
                    inventory.Coffe = false;
                    inventory.Food = false;
                    inventory.Keys = false;
                    inventory.SmartPhone = false;
                    inventory.Wallet = false;
                    break;
                case CharacterIs.Markus:
                    inventory.BusCard = false;
                    inventory.Coffe = false;
                    inventory.Food = false;
                    inventory.Keys = false;
                    inventory.SmartPhone = false;
                    inventory.Wallet = false;
                    break;
            }            
        }


    }



    public enum CharacterIs
    {
        Mimmi,
        Markus,
        Ahmad
    }
}
