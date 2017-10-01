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
        private bool alive = true;
        private Room currentPosition;
        CenterText centerText = new CenterText();

        public void Playing(Player player)
        {
            //Startposition
            currentPosition = new Home(player.Character);

            // loopen fortsätter så länge du lever && du inte har nått endpoint (klassrummet)
            while (alive && currentPosition.endpoint == false)
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
                    if (wordSplit[0].ToLower() == "get")
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
                    else if ((wordSplit[0].ToLower() == "drop"))
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
                    else if ((wordSplit[0].ToLower() == "exit"))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n");

                        // Kolla om exit finns på rummet och ifall enbart 2 ord skrivits in
                        if (CheckIfExitExists(currentPosition, wordSplit[1]) && wordSplit.Length == 2)
                        {
                            if (wordSplit[1].ToLower() == "bed")
                            {
                                centerText.WriteTextAndCenter("Bad choice....\n\n");
                                centerText.WriteTextAndCenter("GAME OVER\n\n");
                                alive = false;
                            }
                            else if (wordSplit[1].ToLower() == "home")
                            {
                                centerText.WriteTextAndCenter("You chose to go home... You will never make it to school today!" +
                                                              " You better call in sick today!\n");
                                centerText.WriteTextAndCenter("GAME OVER\n\n");
                                alive = false;
                            }
                            else
                            {
                                currentPosition.Position(ref currentPosition, player,
                                    CheckIfItemsExist(player, "keys"), CheckIfItemsExist(player, "loaded buscard"),
                                    CheckIfItemsExist(player, "smartphone"), CheckIfItemsExist(player, "coffe"), ref alive);

                                // Inspektera current position och dess items
                                if (currentPosition.endpoint == false && alive == true) Look();

                            }

                        }
                        // Felmeddelande om exit inte finns
                        else
                        {
                            centerText.WriteTextAndCenter("The exit you are trying to use doesn't exist");
                        }
                        break;
                    }
                    else if ((wordSplit[0].ToLower() == "look"))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n");

                        Look();
                        break;
                    }
                    else if ((wordSplit[0].ToLower() == "check"))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n");

                        // Inspektera spelarens items
                        centerText.WriteTextAndCenter("Items in your bag: ");
                        player.WriteitemsList(player);
                        break;
                    }
                    else if ((wordSplit[0].ToLower() == "quit"))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n");

                        centerText.WriteTextAndCenter("You gave up!");
                        alive = false;
                        break;
                    }
                    else if ((wordSplit[0].ToLower() == "use"))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n");

                        //Use item on item
                        if (wordSplit[0].ToLower() == "use" &&
                            CheckIfItemsExist(player, wordSplit[1]) == true &&
                            wordSplit[2].ToLower() == "on" &&
                            CheckIfItemsExist(player, wordSplit[3]) == true &&
                            wordSplit.Length == 4)
                        {
                            Items useItems = ConvertTextToitems(player, wordSplit[1]);
                            Items onItems = ConvertTextToitems(player, wordSplit[3]);

                            // kolla money mot tomt busskort
                            if (useItems.Name == new Money().Name && onItems.Name == new BusCardEmpty().Name)
                            {
                                player.Drop(player, wordSplit[1]);
                                player.Drop(player, wordSplit[3]);

                                Items busCardLoaded = new BusCardLoaded();
                                player.itemList.Add(busCardLoaded);

                                Console.ForegroundColor = ConsoleColor.Green;
                                centerText.WriteTextAndCenter($"Succesfully converted {wordSplit[1]} and " +
                                                              $"{wordSplit[3]} to {busCardLoaded.Name}");
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                GetItemsFrom(currentPosition);
                                currentPosition.isLocked = false;
                            }
                            else
                            {
                                centerText.WriteTextAndCenter("Try another combo, but");
                                centerText.WriteTextAndCenter(
                                    "to be able to travel you need to convert money to another object");
                            }
                        }
                        //Use item on exit
                        else if (wordSplit[0].ToLower() == "use" &&
                                 CheckIfItemsExist(player, wordSplit[1]) == true &&
                                 wordSplit[2].ToLower() == "on" &&
                                 CheckIfExitExists(currentPosition, wordSplit[3]) == true &&
                                 wordSplit.Length == 4)
                        {
                            // Ifall items används på exit 
                            Items useItems = ConvertTextToitems(player, wordSplit[1]);

                            // Kolla smartphone och cab
                            if (useItems.Name.ToLower() == new SmartPhone().Name.ToLower() && 
                                wordSplit[3].ToLower() == new Cab().Name.ToLower())
                            {
   
                                SuccesfullyOpenedExit(player);
                                Look();
                            }
                            //kolla keys mot door
                            else if (useItems.Name.ToLower() == "keys" &&
                                     wordSplit[3].ToLower() == "door" && currentPosition.Name ==
                                     new ToSchool().Name) 
                            {

                                SuccesfullyOpenedExit(player);
                                Look();
                            }
                            // kolla laddat busskort mot bussen
                            else if (useItems.Name.ToLower() == new BusCardLoaded().Name.ToLower() &&
                                     wordSplit[3].ToLower() == "bus" && currentPosition.Name ==
                                     new ToBus(player.Character).Name)
                            {

                                SuccesfullyOpenedExit(player);
                                Look();
                            }
                            else
                            {
                                centerText.WriteTextAndCenter("The item you are trying to use on the exit doesn't work.");
                            }
                        }
                        else
                        {
                            // Skriv ut ifall orden som använder försöker använda inte fungerar
                            centerText.WriteTextAndCenter("You need to have items in your " +
                                                          "bag to be able to use item on an item or exit");
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
                            centerText.WriteTextAndCenter(currentPosition.ExitWithDescription[wordSplit[1]]);
                            Console.WriteLine();
                        }

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

        private void SuccesfullyOpenedExit(Player player)
        {
            currentPosition.isLocked = false;

            Console.ForegroundColor = ConsoleColor.Green;
            centerText.WriteTextAndCenter("You succesfully opened the exit\n");

            Console.ForegroundColor = ConsoleColor.Cyan;

            // get into a new room
            currentPosition.Position(ref currentPosition, player,
                CheckIfItemsExist(player, "keys"), CheckIfItemsExist(player, new BusCardLoaded().Name),
                CheckIfItemsExist(player, "smartphone"), CheckIfItemsExist(player, "coffe"), ref alive);
        }

        private void Look()
        {
            currentPosition.Describe(currentPosition);
            GetItemsFrom(currentPosition);
            GetExitsFrom(currentPosition);
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


