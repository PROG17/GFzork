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

        public Dictionary<Room, List<Inventory>> dictOfRoomAndInventory = new Dictionary<Room, List<Inventory>>();
        CenterText centerText = new CenterText();
        


        public void Playing(Player player)
        {
            CreateStartingPointForRooms();

            //Mimmis värld
            if (player.Character == CharacterIs.Mimmi)
            {
                //Startposition
                currentPosition = new Home();
                Stories story = new HomeToTrain();

                while (alive)
                {
                    
                    WriteAndReadCommandos();

                    while (true)
                    {
                        //Console.Clear();
                        Console.WriteLine("\n");

                        // Felhantering om användaren skriver in enbart "pick", "drop", "exit", "inspect"
                        if (commando == Commandos.Get.ToString().ToLower() /*|| commando == Commandos.Exit.ToString().ToLower()*/
                        || commando == Commandos.Drop.ToString().ToLower() || commando == Commandos.Inspect.ToString().ToLower()
                        )
                        {
                            centerText.WriteTextAndCenter($"{commando} what?\n");
                            break;
                        } else if (commando == Commandos.Use.ToString().ToLower())
                        {
                            centerText.WriteTextAndCenter($"{commando} what on what?\n");
                            break;
                        }


                        // Fortsättning av att kolla commandot
                        if (commando.Contains(Commandos.Get.ToString().ToLower()))
                        {
                            // Ta upp något
                            List<Inventory> storage = TakeOutRoomList(currentPosition);
                            string[] wordSplit = commando.Split(' ');
                            player.Pick(player, wordSplit[1], storage);
                            Console.WriteLine("\n");

                            // Ta bort föremålet från rummet
                            Inventory checkInventory = player.ConvertTextToInventory(player, wordSplit[1]);
                            AddInventoryToRoom(checkInventory);

                            break;
                        }
                        else if (commando.Contains(Commandos.Drop.ToString().ToLower()))
                        {
                            // Droppa något
                            player.Drop(player, commando.Substring(5));

                            // Lägg till det som droppas i rummet
                            Inventory checkInventory = player.ConvertTextToInventory(player, commando.Substring(5));
                            dictOfRoomAndInventory[currentPosition].Add(checkInventory);

                            Console.WriteLine("\n");
                            break;
                        }
                        else if (commando.Contains(Commandos.Exit.ToString().ToLower()))
                        {
                            story.Story(ref story);
                            currentPosition.Position(ref currentPosition, ref story);
                            break;
                        }
                        else if (commando == Commandos.Look.ToString().ToLower())
                        {
                            // Inspektera current position och dess inventory
                            currentPosition.Inspect(currentPosition);
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
                                Inventory useInventory = player.ConvertTextToInventory(player, wordSplit[1]);
                                Inventory onInventory = player.ConvertTextToInventory(player, wordSplit[3]);

                                if (useInventory.Name == new Money().Name && onInventory.Name == new BusCard().Name)
                                {
                                    player.Drop(player, wordSplit[1]);
                                    player.Drop(player, wordSplit[3]);
                                    Inventory busCardLoaded = new BusCardLoaded();
                                    player.inventoryList.Add(busCardLoaded);
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
                            Inventory checkInventory = new Inventory();

                            // Visa bio för föremål
                            if (player.CheckIfInventoryExist(player, commando.Substring(8)) == true)
                            {
                                // Kollar commando mot inventory i rummet
                                checkInventory = player.ConvertTextToInventory(player, commando.Substring(8));

                            }
                            else if (CheckIfInventoryExistInRoom(currentPosition, commando.Substring(8)) == true)
                            {
                                // Kollar commando mot inventory i rummet
                                checkInventory = ConvertTextToInventoryFromRoom(currentPosition, commando.Substring(8));

                            }

                            player.Inspect(checkInventory);


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

            //Markus värld
            if (player.Character == CharacterIs.Markus)
            {
                
            }
            // Ahmads värld
            if (player.Character == CharacterIs.Ahmad)
            {
                
            }

        }


        private Inventory ConvertTextToInventoryFromRoom(Room room, string text)
        {
            Inventory inventory = new Inventory();

            foreach (var item in dictOfRoomAndInventory)
            {
                if (item.Key.ToString() == room.ToString())
                {
                    foreach (var item2 in item.Value)
                    {
                        if (item2.Name.ToLower() == text.ToLower()) return item2;
                    }
                }
            }

            return inventory;
        }

        private void AddInventoryToRoom(Inventory checkInventory)
        {
            
            foreach (var item in dictOfRoomAndInventory)
            {
                if (item.Key.Name.ToLower() == currentPosition.Name.ToLower())
                {
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        if (item.Value[i].Name.ToLower() == checkInventory.Name.ToLower())
                        {
                            item.Value.RemoveAt(i);
                        }
                    }
                }
            }
        }

        public bool CheckIfInventoryExistInRoom(Room room, string text)
        {
            bool control = false;

            foreach (var item in dictOfRoomAndInventory)
            {
                if (item.Key.ToString() == room.ToString())
                {
                    foreach (var item2 in item.Value)
                    {
                        if (item2.Name.ToLower() == text.ToLower()) control = true;
                    }
                }
            }

            return control;
        }


        private void CreateStartingPointForRooms()
        {
            //Objekt för rooms
            Cab cab = new Cab();
            Bus bus = new Bus();
            Home home = new Home();
            School school = new School();
            Train train = new Train();

            //Objekt för inventories
            SmartPhone smartPhone = new SmartPhone();
            BusCard busCard = new BusCard();
            Coffe coffe = new Coffe();
            Food food = new Food();
            Keys keys = new Keys();
            Money money = new Money();
            //Wallet wallet = new Wallet();

            // Inventory for Home
            List<Inventory> inventoryHome = new List<Inventory> { smartPhone, busCard, keys, food, coffe, money };
            dictOfRoomAndInventory.Add(home, inventoryHome);

            // Inventory for Cab
            List<Inventory> inventoryCab = new List<Inventory> { smartPhone, money };
            dictOfRoomAndInventory.Add(cab, inventoryCab);

            // Inventory for Bus
            List<Inventory> inventoryBus = new List<Inventory> { smartPhone, busCard, keys };
            dictOfRoomAndInventory.Add(bus, inventoryBus);

            // Inventory for Train
            List<Inventory> inventoryTrain = new List<Inventory> { };
            dictOfRoomAndInventory.Add(train, inventoryTrain);

            // Inventory for School
            List<Inventory> inventorySchool = new List<Inventory> { coffe, food };
            dictOfRoomAndInventory.Add(school, inventorySchool);

        }

        private void GetInventoryFrom(Room room)
        {

            //var items = dictOfRoomAndInventory[room];
            Console.WriteLine("\n");
            centerText.WriteTextAndCenter($"Inventory available in {room.Name}: ");

            foreach (var item in dictOfRoomAndInventory)
            {
                if (item.Key.ToString() == room.ToString())
                {
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        centerText.WriteTextAndCenter($"{i + 1}){item.Value[i].Name}");
                    }
                }
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

        private List<Inventory> TakeOutRoomList(Room room)
        {
            List<Inventory> listHolder=new List<Inventory>();

            foreach (var item in dictOfRoomAndInventory)
            {
                if (item.Key.ToString() == room.ToString())
                {
                    listHolder= item.Value;
                }
            }
            return listHolder;
            
        }

    }

    public enum Commandos
    {
        Get, Drop, Look, Exit, Use, Quit, Check, Inspect
    }


}

