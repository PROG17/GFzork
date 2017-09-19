using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Inventory
    {
        public bool BusCard { get; set; }
        public bool Wallet { get; set; }
        public bool Coffe { get; set; }
        public bool Keys { get; set; }
        public bool SmartPhone { get; set; }
        public bool Food { get; set; }
        public int BusCardMoney { get; set; }
        public int WalletMoney { get; set; }

        public Inventory()
        {
            BusCard = false;
            Wallet = false;
            Coffe = false;
            Keys = false;
            SmartPhone = false;
            Food = false;
            BusCardMoney = 0;
            WalletMoney = 0;
        }
    }

}
