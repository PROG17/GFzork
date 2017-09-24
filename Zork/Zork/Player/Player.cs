using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    
    public class Player: ContainerForBasicInfo
    {
        public CharacterIs Character { get; protected set; }
        public List<Inventory> inventoryList = new List<Inventory>();

        public void WriteInventoryList(Player player)
        {
            CenterText centerText = new CenterText();

            for (int i = 0; i < player.inventoryList.Count; i++)
            {
                centerText.WriteTextAndCenter($"{i + 1}){player.inventoryList[i].Name}");
            }          
        }

        public Inventory ConvertTextToInventory(Player player, string text)
        {
            Inventory inventory = new Inventory();

            foreach (var item in player.inventoryList)
            {
                if (item.Name.ToLower() == text.ToLower()) inventory = item;
            }

            return inventory;
        }

        public bool CheckIfInventoryExist(Player player, string text)
        {
            bool control = false;
            foreach (var item in player.inventoryList)
            {
                if (item.Name.ToLower() == text.ToLower()) control = true;
            }

            return control;
        }

        public void Pick(Player player, string text, List<Inventory> helpList)
        {
            foreach (var item in helpList)
            {
                if (item.Name.ToLower() == text.ToLower())
                {
                    player.inventoryList.Add(item);
                    break;
                }
            }
        }

        public void Drop(Player player, string text)
        {
            for (int i = 0; i < player.inventoryList.Count; i++)
            {
                if (player.inventoryList[i].Name.ToLower() == text.ToLower())
                {
                    player.inventoryList.RemoveAt(i);
                }
            }
        }


        public void Inspect(Inventory inventory)
        {
            CenterText centerText = new CenterText();
            centerText.WriteTextAndCenter(inventory.Bio);
        }


    }



    public enum CharacterIs
    {
        Mimmi,
        Markus,
        Ahmad
    }
}
