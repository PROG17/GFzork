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
    
     public class Inventory
     {
        public string BusCard { get; set; } = "Buscard";
        public string Money { get; set; } = "Money";
        public string Coffee { get; set; } = "Coffee";
        public string Keys { get; set; } = "Keys";
        public string SmartPhone { get; set; } = "Smartphone";
        public string Food { get; set; } = "Food";
        public string Wallet { get; set; } = "Wallet";

        public int BusCardMoney { get; set; }
        public int WalletMoney { get; set; }

    }
}
