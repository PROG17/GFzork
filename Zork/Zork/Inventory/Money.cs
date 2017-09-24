using System;

namespace Zork
{
    public class Money : Inventory
    {
        public int Cash { get; set; }
        public Money()
        {
            Random rnd = new Random();
            Cash = rnd.Next(0, 100 + 1);
            Name = "Money";
            Bio = "Bio for money";

        }

    }
}