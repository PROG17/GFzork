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

        public void CheckInventoryList(Player player)
        {
            CenterText centerText = new CenterText();

            for (int i = 0; i < player.inventoryList.Count; i++)
            {
                centerText.WriteTextAndCenter($"{i + 1}){player.inventoryList[i].Name}");
            }
            
        }


        public void Pick(Player player, string text, List<Inventory> helpList)
        {
            foreach (var item in helpList)
            {
                if (item.Name.ToLower() == text.ToLower())
                {
                    player.inventoryList.Add(item);
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
    }


    public enum CharacterIs
    {
        Mimmi,
        Markus,
        Ahmad
    }
}
