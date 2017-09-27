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
        public List<Items> itemList = new List<Items>();

        public void WriteitemsList(Player player)
        {
            CenterText centerText = new CenterText();

            for (int i = 0; i < player.itemList.Count; i++)
            {
                centerText.WriteTextAndCenter($"{i + 1}) {player.itemList[i].Name}");
            }          
        }

        public void Pick(Player player, string text, List<Items> roomItems)
        {
            int counter = 0;
            foreach (var item in roomItems)
            {
                if (item.Name.ToLower() == text.ToLower())
                {
                    player.itemList.Add(item);
                    roomItems.RemoveAt(counter);
                    break;
                }
                counter++;
            }
        }

        public void Drop(Player player, string text, List<Items> roomItems)
        {
            for (int i = 0; i < player.itemList.Count; i++)
            {
                if (player.itemList[i].Name.ToLower() == text.ToLower())
                {
                    roomItems.Add(player.itemList[i]);
                    player.itemList.RemoveAt(i);
                }
            }
        }

        public void Drop(Player player, string text)
        {
            for (int i = 0; i < player.itemList.Count; i++)
            {
                if (player.itemList[i].Name.ToLower() == text.ToLower())
                {
                    player.itemList.RemoveAt(i);
                }
            }
        }


        public void Inspect(Items items)
        {
            CenterText centerText = new CenterText();
            centerText.WriteTextAndCenter(items.Bio);
        }


    }



    public enum CharacterIs
    {
        Mimmi,
        Markus,
        Ahmad
    }
}
