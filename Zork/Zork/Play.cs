using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class Play
    {
        public string commando;
        string yourPosition;

        Dictionary<Room, List<Inventory>> dictOfRoomAndInventory = new Dictionary<Room, List<Inventory>>();
        CenterText centerText = new CenterText();


        public void Playing(CharacterIs player)
        {

            Room position = new Room();
            Inventory items = new Inventory();
            Stories story = new Stories();
            var centerText = new CenterText();



            //Mimmis värld
            if (player == CharacterIs.Mimmi)
            {


                bool alive = true;

                //Startposition        
                //yourPosition = position.Home;
                
                

                //centerText.WriteTextAndCenter(position.Home);
                while (alive)
                {
                    CreateStartingPointForRooms();
                    //Inspect eller välj inventory
                    //Console.WriteLine("look where you are [inspect] | pick your inventory [pick]");
                    //commando = Console.ReadLine();
                    //centerText.WriteTextAndCenter(yourPosition);

                    //Inspect eller välj inventory
                    centerText.WriteTextAndCenter("look where you are [inspect] | pick your inventory [pick]");


                    commando = centerText.ReadTextAndCenter(5);





                    if (commando == "pick")
                    {
                        // Skriv ut vilka inventories som finns 
                        Home home = new Home();
                        //position.ItemsHome();
                        GetInventoryFrom(home);

                        story.Home(ref commando, ref yourPosition);

                    }
                    else if (commando == "exit"){ story.Train(ref commando, yourPosition); }


                    else
                    {
                        centerText.WriteTextAndCenter("Try again");
                    }
                }
                //Markus värld
                if (player == CharacterIs.Markus)
                { }
                // Ahmads värld
                if (player == CharacterIs.Ahmad)
                { }




            }

        }
        public void CreateStartingPointForRooms()
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

        public void GetInventoryFrom(Room room)
        {

            //var items = dictOfRoomAndInventory[room];

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
    }
}

