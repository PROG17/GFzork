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
        public bool endpoint = false;
           

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
                    room = new Bus();
                }
                else if (room.Name == new Bus().Name)
                {
                    room = new ToSchool();
                }
                else if (room.Name == new ToBus(player.Character).Name && controlSmartPhone)
                {
                    room = new Cab();
                }
                else if (room.Name == new Cab().Name)
                {
                    room = new ToSchool();
                }
                else if (room.Name == new ToSchool().Name && controlKeys)
                {
                    room = new School();
                }
                else if (room.Name == new School().Name)
                {
                    if (controlCoffe)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        centerText.WriteTextAndCenter("You made it in time for Fredriks lecture " +
                                                      "and you have brought the most important item. COFFE! \n\n");
                        centerText.WriteTextAndCenter("YOU WIN!");
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        // Sätt endpoint på rummet så att spelet avslutas
                        room.endpoint = true;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        centerText.WriteTextAndCenter("Did you forget to bring COFFE?? " +
                                                      "You will die a slowly death...");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        alive = false;
                    }
                }
            }
        }
    }
}

   

