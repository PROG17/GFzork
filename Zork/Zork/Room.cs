using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Room: ContainerForBasicInfo
    {
        // Alla room
        string _home = "This is your home";
        string _homeInspect = "You see a door, and the bed.. Do you want do exit the door or go back to bed?";
        public string Cab { get; set; } = "This is a cab";
        public string Train { get; set; } = "This is a train";
        public string School { get; set; } = "This is the school";
        public string Bus { get; set; } = "This is a bus";
        public string Home
        {
            get => _home;
            set
            {
                if (true)
                {
                    _homeInspect = value;

                }
                _home = value;
            }
        }
        CenterText centerText = new CenterText();


        //Vilka items finns
        Inventory items = new Inventory();
        Dictionary<int, string> itemsHome = new Dictionary<int, string>();

        public void ItemsHome(CharacterIs name)
        {
            
            itemsHome.Add(1, items.SmartPhone);
            itemsHome.Add(2, items.BusCard);
            itemsHome.Add(3, items.Wallet);
            itemsHome.Add(4, items.Coffee);

            foreach(KeyValuePair<int, string> sample in itemsHome)
            {
                centerText.WriteTextAndCenter(sample.ToString());
            }
        }




        //Detaljerad beskrivning beroende på position/vilket rum
        public void Describe(string position)
        {
            if (position == _home) centerText.WriteTextAndCenter(_homeInspect);
        }

    }
}

   

