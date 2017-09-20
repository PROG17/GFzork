using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    
     public class Inventory
    {

        string buscard = "Buscard";
        string coffee = "Coffee";
        string keys = "Keys";
        string smartphone = "Smartphone";
        string food = "Food";
        string money = "Money";
        string wallet = "Wallet";



        public string BusCard
        {
            get
            {
                return buscard;
            }
            set
            {

                value = buscard;
            }
        }
        public string Money
        {
            get
            {
                return money;

            }
            set
            {
                value = money;
            }
        }
        public string Coffee
        {
            get
            {
                return coffee;
            }
            set
            {
                value = coffee;
            }
        }
        public string Keys
        {
            get
            {
                return keys;
            }
            set
            {
                value = keys;
            }
        }
        public string SmartPhone
        {
            get
            {
                return smartphone;

            }
            set
            {
                value = smartphone;

            }
        }
        public string Food
        {
            get
            {
                return food;

            }
            set
            {
                value = food;
            }
        }
        public string Wallet
        {
            get
            {
                return wallet;

            }
            set
            {
                value = Wallet;
            }
        }

        public int BusCardMoney { get; set; }
        public int WalletMoney { get; set; }

        




        
    //public Inventory()
    //    {
    //        BusCard = false;
    //        Wallet = false;
    //        Coffe = false;
    //        Keys = false;
    //        SmartPhone = false;
    //        Food = false;
    //        BusCardMoney = 0;
    //        WalletMoney = 0;

            
    //    }

        //public void Items()
        //{
        //    BusCard = false;
        //    Wallet = false;
        //    Coffe = false;
        //    Keys = false;
        //    SmartPhone = false;
        //    Food = false;
        //    BusCardMoney = 0;
        //    WalletMoney = 0;

            
        //}
        //public void test()
        //{
        //    Inventory user = ...
        //    foreach (PropertyInfo prop in typeof(Inventory).GetProperties())
        //    {
        //        Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(user, null));
        //    }

        //}
    }

}
