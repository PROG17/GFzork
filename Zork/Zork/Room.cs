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
        string homeInspect = "You see a door, and the bed.. Do you want do exit the door or go back to bed?\n" +
            "[exit] | [go back to bed]";
        string trainInspect = "You are now a the train station, do you have your buscard?" +
            "[show buscard] | [forgot it]";

        //Vilka items finns
        Inventory items = new Inventory();

        

        public void ItemsHome()
        {
            List<string> itemsHome = new List<string>();
            itemsHome.Add(items.SmartPhone);
            itemsHome.Add(items.BusCard);
            itemsHome.Add(items.Wallet);
            itemsHome.Add(items.Coffee);
            itemsHome.Add(items.Keys);
            itemsHome.Add(items.Food);
            itemsHome.Add(items.Money);

            foreach (string item in itemsHome)
            {

                     
                Console.Write(item + " ");
                
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
            if (position == train) Console.WriteLine(trainInspect);



        }
    }
}

   

