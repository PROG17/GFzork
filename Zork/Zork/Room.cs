using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{

    class Room
    {
        // Alla room
        string home = "This is your home";
        string cab = "This is a cab";
        string train = "This is a train";
        string school = "This is the school";
        string bus = "This is a bus";
        string homeInspect = "You see a door, and the bed.. Do you want do exit the door or go back to bed?";


        //Vilka items finns
        Inventory items = new Inventory();

        Dictionary<int, string> itemsHome = new Dictionary<int, string> { };

        public void ItemsHome()
        {
            
            itemsHome.Add(1, items.SmartPhone);
            itemsHome.Add(2, items.BusCard);
            itemsHome.Add(3, items.Wallet);
            itemsHome.Add(4, items.Coffee);

            foreach(KeyValuePair<int, string> sample in itemsHome)
     {
                Console.WriteLine(sample.ToString());
            }
        }
        //Detaljerade rumbeskrivningar
        public string Home
        {
            get
            {
                return home;
            }
            set
            {
                if (true)
                {
                    value = homeInspect;

                }

                value = home;
            }
        }
        public string Cab
        {
            get
            {
                return cab;
            }
            set
            {

                value = cab;
            }
        }
        public string Train
        {
            get
            {
                return train;
            }
            set
            {

                value = train;
            }
        }
        public string School
        {
            get
            {
                return school;
            }
            set
            {

                value = school;
            }
        }
        public string Bus
        {
            get
            {
                return bus;
            }
            set
            {

                value = bus;
            }
        }



        //Detaljerad beskrivning beroende på position/vilket rum
        public void Describe(string position)
        {
            if (position == home) Console.WriteLine(homeInspect);




        }
    }
}

   

