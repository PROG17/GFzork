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

        public Items ConvertTextToitems(Player player, string text)
        {
            // default = keys... krävs att texten som kommer in finns för att kunna få korrekt items

            Items items = new Keys();

            foreach (var item in player.itemList)
            {
                if (item.Name.ToLower() == text.ToLower()) items = item;
            }

            return items;
        }

        public bool CheckIfitemsExist(Player player, string text)
        {
            bool control = false;
            foreach (var item in player.itemList)
            {
                if (item.Name.ToLower() == text.ToLower()) control = true;
            }

            return control;
        }

        public void Pick(Player player, string text, List<Items> helpList)
        {
            foreach (var item in helpList)
            {
                if (item.Name.ToLower() == text.ToLower())
                {
                    player.itemList.Add(item);
                    break;
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
