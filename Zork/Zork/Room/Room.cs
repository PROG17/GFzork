using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    
    public class Room : ContainerForBasicInfo, IRoom
    {
        public string[] Exit { get; set; }
        public Dictionary<string, string> ExitWithDescription = new Dictionary<string, string>();
        public List<Items> itemsList = new List<Items>();


        public void Inspect(Room room)
        {
            CenterText centerText = new CenterText();
            centerText.WriteTextAndCenter(room.Bio);

        }

        public bool CheckIfExitExists(Room room, string text)
        {
            bool control = false;
            for (int i = 0; i < room.ExitWithDescription.Count; i++)
            {
                if (room.ExitWithDescription.Keys.ToString().ToLower() == text.ToLower())
                {
                    control = true;
                }
            }
            return control;
        } 
       


        //Metod som tar in första position (Home) och ändrar värdet för varje exit-commando
        public void Position(ref Room room, ref Stories story, Player player)
        {



            if (room.Name == "Home") { room = new Train(); story = new TrainToBus(); return; }
            if (room.Name == "Train") { room = new Bus(); story = new BusToSchool(); return; }
            if (room.Name == "Bus")
            {

                room = new School();
                if (room.Name == "School" && player.CheckIfInventoryExist(player, "Keys"))
                {
                    Console.WriteLine("YOU WIN!");
                    Console.ReadLine();
                       
                }

                return;

            }
        }

    }
}

   

