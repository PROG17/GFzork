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
        CenterText centerText = new CenterText();
        private Stories story;


        public void Playing(Player player)
        {
            //Startposition
            currentPosition = new Home(player.Character);

            while (alive)
            {
                WriteAndReadCommandos();

                while (true)
                {
                    Console.WriteLine("\n");

                    // Felhantering om användaren skriver in enbart "pick", "drop", "exit", "inspect"
                    if (commando == Commandos.Get.ToString().ToLower() ||
                        commando == Commandos.Exit.ToString().ToLower()
                        || commando == Commandos.Drop.ToString().ToLower() ||
                        commando == Commandos.Inspect.ToString().ToLower()
                    )
                    {
                        Console.Clear();
                        centerText.WriteTextAndCenter($"{commando} what?\n");
                        break;
                    }
                    else if (commando == Commandos.Use.ToString().ToLower())
                    {
                        Console.Clear();
                        centerText.WriteTextAndCenter($"{commando} what on what?\n");
                        break;
                    }

                    // Dela upp commandot till en array
                    string[] wordSplit = commando.Split(' ');

                    // Fortsättning av att kolla commandot
                    if (commando.Contains(Commandos.Get.ToString().ToLower()))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n");
                        if (CheckIfItemsExist(currentPosition, wordSplit[1]))
                        {
                            // Ta upp något
                            player.Pick(player, wordSplit[1], currentPosition.itemsList);
                        }
                        else
                        {
                            centerText.WriteTextAndCenter("The item you are trying to get are missing in the room");
                        }

                        // Inspektera spelarens items
                        Console.WriteLine("\n");
                        centerText.WriteTextAndCenter("Items in your bag: ");
                        player.WriteitemsList(player);
                        break;
                    }
                    else if (commando.Contains(Commandos.Drop.ToString().ToLower()))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n");

                        if (CheckIfItemsExist(player, wordSplit[1]))
                        {
                            // Droppa något
                            player.Drop(player, wordSplit[1], currentPosition.itemsList);
                        }
                        else
                        {
                            centerText.WriteTextAndCenter(
                                "The item you are trying to drop are missing in the your bag");
                        }

                        // Inspektera spelarens items
                        Console.WriteLine("\n");
                        centerText.WriteTextAndCenter("Items in your bag: ");
                        player.WriteitemsList(player);
                        Console.WriteLine("\n");
                        break;
                    }
                    else if (commando.Contains(Commandos.Exit.ToString().ToLower()))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n");

                        if (CheckIfExitExists(currentPosition, wordSplit[1]) && wordSplit.Length == 2)
                        {
                            Exit(player);

                        }
                        else
                        {
                            centerText.WriteTextAndCenter("The exit you are trying to use doesn't exist");
                        }


                        break;
                    }
                    else if (commando == Commandos.Look.ToString().ToLower())
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n");

                        // Inspektera current position och dess items
                        currentPosition.Describe(currentPosition);
                        GetItemsFrom(currentPosition);
                        GetExitsFrom(currentPosition);
                        break;
                    }
                    else if (commando == Commandos.Check.ToString().ToLower())
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n");

                        // Inspektera spelarens items
                        centerText.WriteTextAndCenter("Items in your bag: ");
                        player.WriteitemsList(player);
                        break;
                    }
                    else if (commando == Commandos.Quit.ToString().ToLower())
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n");

                        centerText.WriteTextAndCenter("You gave up!");
                        alive = false;
                        break;
                    }
                    else if (commando.Contains(Commandos.Use.ToString().ToLower()))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n");
                        if (wordSplit.Length == 4)
                        {
                            if (wordSplit[0].ToLower() == "use" &&
                                CheckIfItemsExist(player, wordSplit[1]) == true &&
                                wordSplit[2].ToLower() == "on" &&
                                CheckIfItemsExist(player, wordSplit[3]) == true)
                            {
                                Items useItems = ConvertTextToitems(player, wordSplit[1]);
                                Items onItems = ConvertTextToitems(player, wordSplit[3]);

                                if (useItems.Name == new Money().Name && onItems.Name == new BusCard().Name)
                                {
                                    player.Drop(player, wordSplit[1]);
                                    player.Drop(player, wordSplit[3]);

                                    Items busCardLoaded = new BusCardLoaded();
                                    player.itemList.Add(busCardLoaded);
                                    centerText.WriteTextAndCenter($"Succesfully converted {wordSplit[1]} and " +
                                                                  $"{wordSplit[3]} to {busCardLoaded.Name}");
                                    GetItemsFrom(currentPosition);
                                }
                                else
                                {
                                    centerText.WriteTextAndCenter("Try another combo, but");
                                    centerText.WriteTextAndCenter(
                                        "to be able to travel you need to convert money to another object");
                                }
                            }
                            else
                            {
                                centerText.WriteTextAndCenter("You need to have items in your " +
                                                              "bag to be able to use item on item");
                            }
                            break;
                        }
                        else if (commando.Contains(Commandos.Inspect.ToString().ToLower()))
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\n\n");
                            Items checkItems;

                            // Visa bio för föremål
                            if (CheckIfItemsExist(player, wordSplit[1]) == true)
                            {
                                // Kollar commando mot items i rummet
                                checkItems = ConvertTextToitems(player, wordSplit[1]);
                                player.Inspect(checkItems);

                            }
                            else if (CheckIfItemsExist(currentPosition, wordSplit[1]) == true)
                            {
                                // Kollar commando mot items i rummet
                                checkItems = ConvertTextToitems(currentPosition, wordSplit[1]);
                                player.Inspect(checkItems);
                            }
                            else if (CheckIfExitExists(currentPosition, wordSplit[1]) == true)
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
        }

        private void Exit(Player player)
        {
            story.Story(ref story);

            currentPosition.Position(ref currentPosition, ref story, player,
                CheckIfItemsExist(player, "keys"), CheckIfItemsExist(player, "loaded buscard"),
                CheckIfItemsExist(player, "smartphone"));

            if (currentPosition.isLocked)
            {
                if (CheckIfItemsExist(player, new BusCardLoaded().Name))
                {
                    currentPosition.isLocked = false;
                    //centerText.WriteTextAndCenter("It's okey to enter!");

                    // Inspektera current position och dess items
                    currentPosition.Describe(currentPosition);
                    GetItemsFrom(currentPosition);
                    GetExitsFrom(currentPosition);
                }
                else
                {
                    centerText.WriteTextAndCenter($"To be able to enter the {currentPosition.Name}, " +
                                                  $"you need to unlock the door with an item.");
                }
            }
            else
            {

                // Inspektera current position och dess items
                currentPosition.Describe(currentPosition);
                GetItemsFrom(currentPosition);
                GetExitsFrom(currentPosition);
            }

        }

        private Items ConvertTextToitems(Room room, string text)
        {
            // Default blir keys... om inte texten kontrolleras innan
            Items items = new Keys();

            foreach (var item in room.itemsList)
            {
                if (item.Name.ToLower() == text.ToLower()) return item;
            }

            return items;
        }

        public Items ConvertTextToitems(Player player, string text)
        {
            // Default blir keys... om inte texten kontrolleras innan
            Items items = new Keys();

            foreach (var item in player.itemList)
            {
                if (item.Name.ToLower() == text.ToLower()) items = item;
            }

            return items;
        }



        public bool CheckIfItemsExist(Room room, string text)
        {
            bool control = false;

            foreach (var item in room.itemsList)
            {
                if (item.Name.ToLower() == text.ToLower()) control = true;
            }

            return control;
        }

        public bool CheckIfItemsExist(Player player, string text)
        {
            bool control = false;
            foreach (var item in player.itemList)
            {
                if (item.Name.ToLower() == text.ToLower()) control = true;
            }

            return control;
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



        private void GetItemsFrom(Room room)
        {
            Console.WriteLine("\n");
            centerText.WriteTextAndCenter($"Items available in {room.Name}: ");

            for (int i = 0; i < room.itemsList.Count; i++)
            {
                centerText.WriteTextAndCenter($"{i + 1}){room.itemsList[i].Name}");
            }
        }

        private void GetExitsFrom(Room room)
        {
            Console.WriteLine("\n");
            centerText.WriteTextAndCenter($"Exits available in {room.Name}: ");

            int counter = 0;
            foreach (var item in room.ExitWithDescription)
            {
                centerText.WriteTextAndCenter($"{counter + 1}){item.Key}");
                counter++;
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
}

