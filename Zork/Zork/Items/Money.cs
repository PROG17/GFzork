using System;

namespace Zork
{
    public class Money : Items
    {
        //public int Cash { get; set; }
        public Money()
        {
            Random rnd = new Random();
            //Cash = rnd.Next(0, 100 + 1);
            Name = "money";
            Bio = $"You have a few bucks available to bring with you. Money can be useful!";

        }

    }
}