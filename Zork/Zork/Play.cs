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
            var centerText = new CenterText();


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
                    //Console.WriteLine("look where you are [inspect] | pick your inventory [pick]");
                    //commando = Console.ReadLine();
                    //centerText.WriteTextAndCenter(yourPosition);

                    //Inspect eller välj inventory
                    centerText.WriteTextAndCenter("look where you are [inspect] | pick your inventory [pick]");
                    commando = centerText.ReadTextAndCenter(5);


                    story.Home(ref commando, yourPosition);



                    if (commando == "pick")
                    {  }

                    else
                    {
                        Console.WriteLine("Try again");
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
}

