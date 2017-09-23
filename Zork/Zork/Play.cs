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

        public Dictionary<Room, List<Inventory>> dictOfRoomAndInventory = new Dictionary<Room, List<Inventory>>();
        CenterText centerText = new CenterText();
        private Room currentPosition;


        public void Playing(Player player)
        {
            CreateStartingPointForRooms();

            //Mimmis värld
            if (player.Character == CharacterIs.Mimmi)
            {
                bool alive = true;

                //Startposition
                currentPosition = new Home();
                                           
                while (alive)
                {
                    centerText.WriteTextAndCenter($"Current room -- {currentPosition.Name} --\n");

                    WriteAndReadCommandos();

                    while (true)
                    {
                        if (commando == Commandos.Pick.ToString().ToLower())
                        {
                            GetInventoryFrom(currentPosition);
                            List<Inventory> storage = TakeOutRoomList(currentPosition);

                            string input = Console.ReadLine().ToLower();
                            

                            player.Pick(player, input, storage);
                            // add på player inventory list - metod i player
                            
                            Console.WriteLine("\n");
                            WriteAndReadCommandos();
                            break;
                        }
                        else if (commando == Commandos.Drop.ToString().ToLower())
                        {
                            // player ska droppa inventory - måst lägga till metod i player

                            Console.WriteLine("\n");
                            WriteAndReadCommandos();
                            break;
                        }
                        else if (commando == Commandos.Exit.ToString().ToLower())
                        {
                            // get story from one room to another
                            // change current position
                            break;
                        }
                        else if (commando == Commandos.Inpsect.ToString().ToLower())
                        {   
                            currentPosition.Inspect(currentPosition);
                            break;
                        }
                        else if (commando == Commandos.Check.ToString().ToLower())
                        {
                            player.CheckInventoryList(player);
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
            Wallet wallet = new Wallet();

            // Inventory for Home
            List<Inventory> inventoryHome = new List<Inventory> { smartPhone, busCard, wallet, keys, wallet, food, coffe };
            dictOfRoomAndInventory.Add(home, inventoryHome);

            // Inventory for Cab
            List<Inventory> inventoryCab = new List<Inventory> { smartPhone };
            dictOfRoomAndInventory.Add(cab, inventoryCab);

            // Inventory for Bus
            List<Inventory> inventoryBus = new List<Inventory> { smartPhone, busCard, wallet, keys };
            dictOfRoomAndInventory.Add(bus, inventoryBus);

            // Inventory for Train
            List<Inventory> inventoryTrain = new List<Inventory> { };
            dictOfRoomAndInventory.Add(train, inventoryTrain);

            // Inventory for School
            List<Inventory> inventorySchool = new List<Inventory> { coffe, food };
            dictOfRoomAndInventory.Add(school, inventorySchool);

            //GetInventoryFromRoom(cab);

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
            centerText.WriteTextAndCenter("look where you are [inspect] || pick inventory [pick]");
            centerText.WriteTextAndCenter("drop inventory [drop] || check your inventory [check]");
            centerText.WriteTextAndCenter("take a path [exit]\n");
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
        Pick, Drop, Inpsect, Exit, Check, Use
    }


}

