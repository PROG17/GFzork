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

        Stories story = new Stories();
        Room room = new Room();




        public void Playing(int player)
        {
            // -----------Markus
            //room.CreateStartingPointForRooms();
            //Room current;
            //current = new Cab();
            //Console.WriteLine(current.Name);
            //Console.WriteLine(current.Bio);

            //if (current is Cab)
            //{
            //    var cab = current as Cab;
            //    cab.DescribeTest();
            //}

            //BaseClass myBaseObject = new BaseClass();
            //DerivedClass myDerivedObject = myBaseObject as DerivedClass;

            //myDerivedObject.MyDerivedProperty = true;


            Room position = new Room();
            Inventory items = new Inventory();
            Stories story = new Stories();
            var centerText = new CenterText();



            //Mimmis värld
            if (player == 1)
            {


                bool alive = true;

                //Startposition        
                //yourPosition = position.Home;
                
                

                //centerText.WriteTextAndCenter(position.Home);
                while (alive)
                {

                    //Inspect eller välj inventory
                    //Console.WriteLine("look where you are [inspect] | pick your inventory [pick]");
                    //commando = Console.ReadLine();
                    //centerText.WriteTextAndCenter(yourPosition);

                    //Inspect eller välj inventory
                    centerText.WriteTextAndCenter("look where you are [inspect] | pick your inventory [pick]");


                    commando = centerText.ReadTextAndCenter(5);


                    story.Home(ref commando, ref yourPosition);



                    if (commando == "pick")
                    {
                        // Skriv ut vilka inventories som finns 

                        //position.ItemsHome();
                        position.GetInventoryFrom(new Home());

                    }
                    else if (commando == "exit"){ story.Train(ref commando, yourPosition); }


                    else
                    {
                        centerText.WriteTextAndCenter("Try again");
                    }
                }
                //Markus värld
                if (player == 2)
                { }
                // Ahmads värld
                if (player == 3)
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
            room.dictOfRoomAndInventory.Add(home, inventoryHome);

            // Inventory for Cab
            List<Inventory> inventoryCab = new List<Inventory> { smartPhone };
            room.dictOfRoomAndInventory.Add(cab, inventoryCab);

            // Inventory for Bus
            List<Inventory> inventoryBus = new List<Inventory> { smartPhone, busCard, wallet, keys };
            room.dictOfRoomAndInventory.Add(bus, inventoryBus);

            // Inventory for Train
            List<Inventory> inventoryTrain = new List<Inventory> { };
            room.dictOfRoomAndInventory.Add(train, inventoryTrain);

            // Inventory for School
            List<Inventory> inventorySchool = new List<Inventory> { coffe, food };
            room.dictOfRoomAndInventory.Add(school, inventorySchool);

            //GetInventoryFromRoom(cab);

        }
    }
}

