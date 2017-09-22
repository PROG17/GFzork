using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{


    public class Room : ContainerForBasicInfo
    {
        // Alla room
        //public string _home = "This is your home";
        string _homeInspect = "You see a door, and the bed.. Do you want do exit the door or go back to bed?";
        string _trainInspect = "You're at the train station. Use your buscard";
        //public string Cab { get; } = "This is a cab";
        //public string Train { get; } = "This is a train";
        //public string School { get; } = "This is the school";
        //public string Bus { get; } = "This is a bus";

        //public string Home
        //{
        //    //get => _home;
        //    set
        //    {
        //        if (true)
        //        {
        //            _homeInspect = value;

        //        }
        //        _home = value;
        //    }
        //}


        CenterText centerText = new CenterText();

        //Vilka items finns i varje rum
        Inventory items = new Inventory();
        List<string> itemsHome = new List<string>();

        public void ItemsHome()
        {
            //itemsHome.Add(items.SmartPhone);
            //itemsHome.Add(items.BusCard);
            //itemsHome.Add(items.Wallet);
            //itemsHome.Add(items.Coffee);

            foreach (string item in itemsHome)
            {
                centerText.WriteTextAndCenter(item);

            }
        }

        //Detaljerad beskrivning beroende på position/vilket rum
        //public void Describe(string position)
        //{
        //    if (position == _home) centerText.WriteTextAndCenter(_homeInspect);
        //    if (position == Train) centerText.WriteTextAndCenter(_trainInspect);
        //}


        // --------------- Markus....
        public Dictionary<Room, List<Inventory>> dictOfRoomAndInventory = new Dictionary<Room, List<Inventory>>();

        public void CreateStartingPointForRooms()
        {
            Cab cab = new Cab();
            SmartPhone smartPhone = new SmartPhone();
            BusCard busCard = new BusCard();
            Coffe coffe = new Coffe();
            Food food = new Food();
            Keys keys = new Keys();
            Wallet wallet = new Wallet();

            // Inventory for Cab
            List<Inventory> inventoryCab = new List<Inventory> {smartPhone, busCard, wallet, keys, wallet, food, coffe};
            dictOfRoomAndInventory.Add(cab, inventoryCab);

            List<Inventory> inventoryHome = new List<Inventory> { smartPhone };
            dictOfRoomAndInventory.Add(cab, inventoryHome);

        }

        
        public void GetInventoryFrom(Room room)
        {
            var items = dictOfRoomAndInventory[room];

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}){items[i].Name}");
            }
            
        }
    }
}

   

