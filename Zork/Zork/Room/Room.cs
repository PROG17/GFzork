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
                }
            }
            return control;
        }

        //Metod som tar in första position (Home) och ändrar värdet för varje exit-commando
        public void Position(ref Room room, Player player,
            bool controlKeys, bool controlBusCard, bool controlSmartPhone, 
            bool controlCoffe, ref bool alive)
        {
            CenterText centerText = new CenterText();

            if (room.isLocked == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                centerText.WriteTextAndCenter($"To be able to enter " +
                                              $"you need to unlock the door with an item.\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;

            }
            else
            {
                if (room.Name == new Home(player.Character).Name)
                {
                    room = new ToBus(player.Character); 
                }
                else if (room.Name == new ToBus(player.Character).Name && controlBusCard)
                {
                    room = new School();
                }
                else if (room.Name == new ToBus(player.Character).Name && controlSmartPhone)
                {
                    room = new Cab(player.Character);
                }
                else if (room.Name == new Cab(player.Character).Name)
                {
                    room = new ToSchool(player.Character);
                }
                else if (room.Name == new ToSchool(player.Character).Name && controlKeys)
                {
                    room = new School();
                }
                else if (room.Name == new School().Name)
                {
                    if (controlCoffe)
                    {
                        centerText.WriteTextAndCenter("You have got to school in time for Fredriks lecture " +
                                                      "and have bring the most importent item. COFFE! \n\n" +
                                                      "YOU WIN!");
                    }
                    else
                    {
                        centerText.WriteTextAndCenter("Did you forget to bring COFFE!! " +
                                                      "You will die a slowly death...");
                        alive = false;
                    }
                }
            }
            

            ////Metod som tar in första position (Home) och ändrar värdet för varje exit-commando
            //public void Position(ref Room room, ref Stories story, Player player, 
            //    bool controlKeys, bool controlBusCard, bool controlSmartPhone, ref bool alive)
            //{
            //    CenterText centerText = new CenterText();

            //    if (room.isLocked == true)
            //    {
            //        centerText.WriteTextAndCenter($"To be able to enter " +
            //                                      $"you need to unlock the door with an item.");

            //    }
            //    //else
            //    //{
            //    //    if (room.Name == "Home" && controlBusCard)
            //    //    {
            //    //        //room = new Bus(player.Character);
            //    //        //story = new HomeToBus(player.Character); return;
            //    //    }
            //    //    if (room.Name == "Home" && controlSmartPhone)
            //    //    {
            //    //        //room = new Cab(player.Character);
            //    //        //story = new CabToSchool(); return;
            //    //    }
            //    //    if (room.Name == "Bus" || room.Name == "Cab")
            //    //    {
            //    //        room = new School();

            //    //        if (room.Name == "School" && controlKeys)
            //    //        {
            //    //            Console.WriteLine("You have entered the school and won the game");
            //    //            Environment.Exit(1);
            //    //        }
            //    //        if (room.Name == "School" && !controlKeys)
            //    //        {
            //    //            Console.WriteLine("You dont have the keys with you and can't enter the school...");
            //    //            alive = false;
            //    //        }
            //    //    }
            //    //}
        }
    }
}

   

