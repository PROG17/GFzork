using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{

    public class Player: IInventory
    {
        public string Name { get; set; }
        public CharacterIs Character { get; protected set; }
        public string Bio { get; protected set; }
        Inventory inventory = new Inventory();
        Dictionary<string, bool> inventoryDictionary = new Dictionary<string, bool>();
        

        // Constructor
        public Player()
        {
            //this.Name = name;
            //Character = player;
            //CreateInventoryList(player);
        }


        public virtual void CreateInventory()
        {
            // Change inventory to true if the character should get it
        }


        //private void CreateInventoryList(CharacterIs character)
        //{
        //    switch (character)
        //    {
        //        case CharacterIs.Mimmi:
        //            inventory.BusCard = false;
        //            inventory.Coffe = false;
        //            inventory.Food = false;
        //            inventory.Keys = false;
        //            inventory.SmartPhone = false;
        //            inventory.Wallet = false;
        //            break;
        //        case CharacterIs.Ahmad:
        //            inventory.BusCard = false;
        //            inventory.Coffe = false;
        //            inventory.Food = false;
        //            inventory.Keys = false;
        //            inventory.SmartPhone = false;
        //            inventory.Wallet = false;
        //            break;
        //        case CharacterIs.Markus:
        //            inventory.BusCard = false;
        //            inventory.Coffe = false;
        //            inventory.Food = false;
        //            inventory.Keys = false;
        //            inventory.SmartPhone = false;
        //            inventory.Wallet = false;
        //            break;
        //    }            
        //}



    }



    public enum CharacterIs
    {
        Mimmi,
        Markus,
        Ahmad
    }
}
