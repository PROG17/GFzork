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

        //public Dictionary<Room, List<Items>> dictOfRoomAnditems = new Dictionary<Room, List<Items>>();
        CenterText centerText = new CenterText();



        public void Playing(Player player)
        {
            //Startposition
            currentPosition = new Home(player.Character);
            Stories story = new HomeToTrain(player.Character);

            while (alive)
            {

                WriteAndReadCommandos();

                while (true)
                {
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
                        Items checkItems = player.ConvertTextToitems(player, wordSplit[1]);
                        currentPosition.itemsList.Remove(checkItems);

                        break;
                    }
                    else if (commando.Contains(Commandos.Drop.ToString().ToLower()))
                    {
                        // Droppa något
                        player.Drop(player, commando.Substring(5));

                        // Lägg till det som droppas i rummet
                        Items checkItems = player.ConvertTextToitems(player, commando.Substring(5));
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
                        // Inspektera current position och dess items
                        currentPosition.Describe(currentPosition);
                        GetitemsFrom(currentPosition);
                        break;
                    }
                    else if (commando == Commandos.Check.ToString().ToLower())
                    {
                        // Inspektera spelarens invetory
                        player.WriteitemsList(player);
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

                        if (player.CheckIfitemsExist(player, wordSplit[1]) == true &&
                            player.CheckIfitemsExist(player, wordSplit[3]) == true)
                        {
                            Items useItems = player.ConvertTextToitems(player, wordSplit[1]);
                            Items onItems = player.ConvertTextToitems(player, wordSplit[3]);

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
                        if (player.CheckIfitemsExist(player, wordSplit[1]) == true)
                        {
                            // Kollar commando mot items i rummet
                            checkItems = player.ConvertTextToitems(player, wordSplit[1]);
                            player.Inspect(checkItems);

                        }
                        else if (CheckIfitemsExistInRoom(currentPosition, wordSplit[1]) == true)
                        {
                            // Kollar commando mot items i rummet
                            checkItems = ConvertTextToitemsFromRoom(currentPosition, wordSplit[1]);
                            player.Inspect(checkItems);
                        }
                        else if (currentPosition.CheckIfExitExists(currentPosition, wordSplit[1]) == true)
                        {
                            Console.WriteLine(currentPosition.ExitWithDescription[wordSplit[1]]);
                            
                            Console.WriteLine();
                            
                            
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


        private Items ConvertTextToitemsFromRoom(Room room, string text)
        {
            // Default blir keys... om inte texten kontrolleras innan
            Items items = new Keys();

            foreach (var item in room.itemsList)
            {
                if (item.Name.ToLower() == text.ToLower()) return item;
            }

            return items;
        }



        public bool CheckIfitemsExistInRoom(Room room, string text)
        {
            bool control = false;

            foreach (var item in room.itemsList)
            {
                if (item.Name.ToLower() == text.ToLower()) control = true;
            }

            return control;
        }


        private void GetitemsFrom(Room room)
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
            centerText.WriteTextAndCenter("look where you are [look] || get items [get]");
            centerText.WriteTextAndCenter("drop items [drop] || check your items [check]");
            centerText.WriteTextAndCenter("take a path [exit] || use items on [use - on]");
            centerText.WriteTextAndCenter("inspect items or exit [inspect]\n");
            commando = centerText.ReadTextAndCenter(5).ToLower();

        }



    }

    public enum Commandos
    {
        Get, Drop, Look, Exit, Use, Quit, Check, Inspect
    }


}

