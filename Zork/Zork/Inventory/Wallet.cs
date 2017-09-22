using System;

namespace Zork
{
    public class Wallet : Inventory
    {
        public int WalletMoney { get; set; }
        Random rnd = new Random();

        public Wallet()
        {
            Name = "Wallet";
            Bio = "Bio for wallet";
            WalletMoney = rnd.Next(0, 100 + 1);
        }
    }
}