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
        List<string> itemsHome = new List<string>();

        public void ItemsHome()
        {
            
            itemsHome.Add(items.SmartPhone);
            itemsHome.Add(items.BusCard);
            itemsHome.Add(items.Wallet);
            itemsHome.Add(items.Coffee);

            foreach(string item in itemsHome)
            {
                centerText.WriteTextAndCenter(item);
                
            }
        }




        //Detaljerad beskrivning beroende på position/vilket rum
        public void Describe(string position)
        {
            if (position == _home) centerText.WriteTextAndCenter(_homeInspect);
        }

    }
}

   

