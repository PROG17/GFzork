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


        public string BusCard { get; set; } = "Buscard";
        public string Coffee { get; set; } = "Coffee";
        public string Keys { get; set; } = "Keys";
        public string SmartPhone { get; set; } = "Smartphone";
        public string Food { get; set; } = "Food";
        public string Money { get; set; } = "Money";
        public string Wallet { get; set; } = "Wallet";






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
