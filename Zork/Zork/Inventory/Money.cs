using System;

namespace Zork
{
    public class Money : Items
    {
        public int Cash { get; set; }
        public Money()
        {
            Random rnd = new Random();
            Cash = rnd.Next(0, 100 + 1);
            Name = "Money";
            Bio = $"You have {Cash} SEK available to bring with you. Cash can be useful!";

        }

    }
}