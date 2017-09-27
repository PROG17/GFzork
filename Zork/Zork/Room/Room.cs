using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    
    public abstract class Room : ContainerForBasicInfo, IRoom
    {
        public Dictionary<string, string> ExitWithDescription = new Dictionary<string, string>();
        public List<Items> itemsList = new List<Items>();
        public bool isLocked = true;


        public void Describe(Room room)
        {
            CenterText centerText = new CenterText();
            centerText.WriteTextAndCenter($"Current room: {room.Name}\n");
            centerText.WriteTextAndCenter(room.Bio);
            
        }

        public bool CheckIfExitExists(Room room, string text)
        {
            bool control = false;
            foreach (var item in room.ExitWithDescription)
            {
                if (item.Key.ToLower() == text.ToLower())
                {
                    control = true;
                    //Console.WriteLine(ExitWithDescription.Values);

                }
            }
            return control;
        }



        //Metod som tar in första position (Home) och ändrar värdet för varje exit-commando
        public void Position(ref Room room, ref Stories story, Player player, bool control)
        {



            if (room.Name == "Home") { room = new Train(player.Character); story = new TrainToBus(); return; }
            if (room.Name == "Train") { room = new Bus(); story = new BusToSchool(player.Character); return; }
            if (room.Name == "Bus")
            {

                room = new School();
                if (room.Name == "School" && control)
                {
                    Console.WriteLine("YOU WIN!");
                    Console.ReadLine();
                       
                }

                return;

            }
        }

    }
}

   

