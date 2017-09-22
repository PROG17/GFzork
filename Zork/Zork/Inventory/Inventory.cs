using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Zork
{
    public class Keys : Inventory
    {
        public Keys()
        {
            base.Name = "Keys";
            base.Bio = "Bio of keys";
        }
    }

    public class Coffe : Inventory
    {
        public Coffe()
        {
            base.Name = "Coffe";
            base.Bio = "Bio for coffe";
        }
    }

    public class Money : Inventory
    {
        public Money()
        {
            base.Name = "Money";
            base.Bio = "Bio for Money";
        }
    }

    public class BusCard : Inventory
    {
        public int BusCardMoney { get; set; }
        Random rnd = new Random();


        public BusCard()
        {
            base.Name = "BusCard";
            base.Bio = "Bio for BusCard";
            BusCardMoney = rnd.Next(0, 100 + 1);
        }
    }

    public class Food : Inventory
    {
        public Food()
        {
            base.Name = "Food";
            base.Bio = "Bio for food";
        }
    }

    public class Wallet : Inventory
    {
        public int WalletMoney { get; set; }
        Random rnd = new Random();

        public Wallet()
        {
            base.Name = "Wallet";
            base.Bio = "Bio for wallet";
            WalletMoney = rnd.Next(0, 100 + 1);
        }
    }


    public class Inventory: ContainerForBasicInfo
     {
        //public string BusCard { get; set; } = "Buscard";
        //public string Money { get; set; } = "Money";
        //public string Coffee { get; set; } = "Coffee";
        //public string Keys { get; set; } = "Keys";
        //public string SmartPhone { get; set; } = "Smartphone";
        //public string Food { get; set; } = "Food";
        //public string Wallet { get; set; } = "Wallet";

        //public int BusCardMoney { get; set; }
        //public int WalletMoney { get; set; }

    }
}
