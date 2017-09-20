using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class Play
    {
        string commando;
        string yourPosition;
        
        

        public void Playing(int player)
        {
            Room position = new Room();
            Inventory items = new Inventory();
            Stories story = new Stories();

            //Mimmis värld
            if (player == 1)
            {

                //Startposition        

                yourPosition = position.Home;
                Console.WriteLine(position.Home);
                //Inspect eller välj inventory
                Console.WriteLine("look where you are [inspect] | pick your inventory [pick]");
                commando = Console.ReadLine();

                if (commando == "inspect") { if (yourPosition == position.Home) position.Describe(position.Home); }

                else if (commando == "pick")
                { position.ItemsHome(); }

                else
                {
                    Console.WriteLine("Try again");
                }
                //Markus värld
                if (player == 2)
                { }
                // Ahmads värld
                if (player == 3)
                { }



            }
        }

    }
}
