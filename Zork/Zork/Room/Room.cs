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
        public void Position(ref Room room, ref Stories story, Player player, bool controlBusCard, bool controlKeys, bool controlSmartPhone)
        {

            if(room.Name == "Home") { room = new BetweenRooms(); return; }
            if (room.Name == "Limbo" && controlBusCard == true){ room = new Train(player.Character); story = new TrainToBus(); return; }
            if(room.Name == "Limbo" && controlSmartPhone == true) { room = new Cab(player.Character); story = new CabToSchool(); return; }
            if (room.Name == "Train") { room = new Bus(); story = new BusToSchool(player.Character); return; }
            if (room.Name == "Bus" || room.Name == "Cab")
            {
                room = new BetweenRooms();
                
                if (room.Name == "Limbo" && controlKeys)
                {
                    room = new School();

                    Console.WriteLine("You have entered the school and won the game");
                    Console.ReadLine();
                    Environment.Exit(1);
                }

                return;

            }
        }

    }
}

   

