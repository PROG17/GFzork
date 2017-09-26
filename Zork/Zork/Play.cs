using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class Play
    {
        public string commando;
        bool alive = true;
        private Room currentPosition;

        //public Dictionary<Room, List<Items>> dictOfRoomAndInventory = new Dictionary<Room, List<Items>>();
        CenterText centerText = new CenterText();



        public void Playing(Player player)
        {
            //CreateStartingPointForRooms();

            //Startposition
            currentPosition = new Home(player.Character);
            Stories story = new HomeToTrain(player.Character);

            while (alive)
            {

                WriteAndReadCommandos();

                while (true)
                {
                    //Console.Clear();
                    Console.WriteLine("\n");

                    // Felhantering om användaren skriver in enbart "pick", "drop", "exit", "inspect"
                    if (commando == Commandos.Get.ToString().ToLower() || commando == Commandos.Exit.ToString().ToLower()
                    || commando == Commandos.Drop.ToString().ToLower() || commando == Commandos.Inspect.ToString().ToLower()
                    )
                    {
                        centerText.WriteTextAndCenter($"{commando} what?\n");
                        break;
                    }
                    else if (commando == Commandos.Use.ToString().ToLower())
                    {
                        centerText.WriteTextAndCenter($"{commando} what on what?\n");
                        break;
                    }


                    // Fortsättning av att kolla commandot
                    if (commando.Contains(Commandos.Get.ToString().ToLower()))
                    {
                        // Ta upp något
                        string[] wordSplit = commando.Split(' ');
                        player.Pick(player, wordSplit[1], currentPosition.itemsList);
                        Console.WriteLine("\n");

                        // Ta bort föremålet från rummet
                        Items checkItems = player.ConvertTextToInventory(player, wordSplit[1]);
                        currentPosition.itemsList.Remove(checkItems);

                        break;
                    }
                    else if (commando.Contains(Commandos.Drop.ToString().ToLower()))
                    {
                        // Droppa något
                        player.Drop(player, commando.Substring(5));

                        // Lägg till det som droppas i rummet
                        Items checkItems = player.ConvertTextToInventory(player, commando.Substring(5));
                        currentPosition.itemsList.Add(checkItems);

                        Console.WriteLine("\n");
                        break;
                    }
                    else if (commando.Contains(Commandos.Exit.ToString().ToLower()))
                    {

                        story.Story(ref story);
                        currentPosition.Position(ref currentPosition, ref story, player);
                        break;
                    }
                    else if (commando == Commandos.Look.ToString().ToLower())
                    {
                        // Inspektera current position och dess inventory
                        currentPosition.Describe(currentPosition);
                        GetInventoryFrom(currentPosition);
                        break;
                    }
                    else if (commando == Commandos.Check.ToString().ToLower())
                    {
                        // Inspektera spelarens invetory
                        player.WriteInventoryList(player);
                        break;
                    }
                    else if (commando == Commandos.Quit.ToString().ToLower())
                    {
                        centerText.WriteTextAndCenter("You gave up!");
                        alive = false;
                        break;
                    }
                    else if (commando.Contains(Commandos.Use.ToString().ToLower()))
                    {
                        string[] wordSplit = commando.Split(' ');

                        if (player.CheckIfInventoryExist(player, wordSplit[1]) == true &&
                            player.CheckIfInventoryExist(player, wordSplit[3]) == true)
                        {
                            Items useItems = player.ConvertTextToInventory(player, wordSplit[1]);
                            Items onItems = player.ConvertTextToInventory(player, wordSplit[3]);

                            if (useItems.Name == new Money().Name && onItems.Name == new BusCard().Name)
                            {
                                player.Drop(player, wordSplit[1]);
                                player.Drop(player, wordSplit[3]);
                                Items busCardLoaded = new BusCardLoaded();
                                player.itemList.Add(busCardLoaded);
                                centerText.WriteTextAndCenter($"Succesfully converted {wordSplit[1]} and " +
                                                              $"{wordSplit[3]} to {busCardLoaded.Name}");
                            }
                            else
                            {
                                centerText.WriteTextAndCenter("Try another combo, but");
                                centerText.WriteTextAndCenter("to be able to travel you need to convert money to another object");
                            }
                        }
                        break;
                    }
                    else if (commando.Contains(Commandos.Inspect.ToString().ToLower()))
                    {
                        Items checkItems;
                        string[] wordSplit = commando.Split(' ');

                        // Visa bio för föremål
                        if (player.CheckIfInventoryExist(player, wordSplit[1]) == true)
                        {
                            // Kollar commando mot inventory i rummet
                            checkItems = player.ConvertTextToInventory(player, wordSplit[1]);
                            player.Inspect(checkItems);

                        }
                        else if (CheckIfInventoryExistInRoom(currentPosition, wordSplit[1]) == true)
                        {
                            // Kollar commando mot inventory i rummet
                            checkItems = ConvertTextToInventoryFromRoom(currentPosition, wordSplit[1]);
                            player.Inspect(checkItems);
                        }
                        else if (currentPosition.CheckIfExitExists(currentPosition, wordSplit[1]) == true)
                        {

                            }


                        // Visa bio for utgång

                        break;
                    }
                    else
                    {
                        centerText.WriteTextAndCenter("Try again");
                        commando = centerText.ReadTextAndCenter(5).ToLower();
                    }
                }
            }
        }


        private Items ConvertTextToInventoryFromRoom(Room room, string text)
        {
            // Default blir keys... om inte texten kontrolleras innan
            Items items = new Keys();

            foreach (var item in room.itemsList)
            {
                if (item.Name.ToLower() == text.ToLower()) return item;
            }

            return items;
        }



        public bool CheckIfInventoryExistInRoom(Room room, string text)
        {
            bool control = false;

            foreach (var item in room.itemsList)
            {
                if (item.Name.ToLower() == text.ToLower()) control = true;
            }

            return control;
        }


        private void GetInventoryFrom(Room room)
        {

            Console.WriteLine("\n");
            centerText.WriteTextAndCenter($"Items available in {room.Name}: ");

            for (int i = 0; i < room.itemsList.Count; i++)
            {
                centerText.WriteTextAndCenter($"{i + 1}){room.itemsList[i].Name}");
            }


        }

        private void WriteAndReadCommandos()
        {
            Console.WriteLine("\n");
            centerText.WriteTextAndCenter("look where you are [look] || get inventory [get]");
            centerText.WriteTextAndCenter("drop inventory [drop] || check your inventory [check]");
            centerText.WriteTextAndCenter("take a path [exit] || use inventory on [use - on]");
            centerText.WriteTextAndCenter("inspect inventory or exit [inspect]\n");
            commando = centerText.ReadTextAndCenter(5).ToLower();

        }



    }

    public enum Commandos
    {
        Get, Drop, Look, Exit, Use, Quit, Check, Inspect
    }


}

