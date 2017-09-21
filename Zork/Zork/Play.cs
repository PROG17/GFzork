using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class Play
    {
        public string commando;
        string yourPosition;
        
        Stories story = new Stories();


        public void Playing(int player)
        {
            Room position = new Room();
            Inventory items = new Inventory();
            Stories story = new Stories();


            //Mimmis värld
            if (player == 1)
            {
                bool alive = true;

                //Startposition        
                yourPosition = position.Home;
                Console.WriteLine(position.Home);
                while (alive)
                {
                    
                    //Inspect eller välj inventory
                    Console.WriteLine("look where you are [inspect] | pick your inventory [pick]");
                    commando = Console.ReadLine();


                    story.Home(ref commando, yourPosition);
                    Console.WriteLine("Exit");





                }
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

