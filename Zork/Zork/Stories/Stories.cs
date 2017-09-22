using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Stories
    {
        // Skapa dict i dict!!

        //Text strängar som ska kallas på

        //Hem
        //
        //Buss/Tåg/helikopter
        //
        //Odenplan
        //
        //Buss/Tåg
        //
        //Skolan
        public List<string> myInventory = new List<string>();
        Room position = new Room();
        CenterText centerText = new CenterText();


        public void Home(ref string commando, ref string yourPosition)
        {
            if (commando == "inspect")
            {
                if (yourPosition == position.Home)
                {
                    position.Describe(position.Home);
                    commando = Console.ReadLine();

                    if (commando == "exit")
                    {
                        commando = "exit";
                        yourPosition = position.Train;

                    }

                }
               
            }
            
           
        
            else if (commando == "pick")
            {
                Console.WriteLine("Pick 3 items");
                position.ItemsHome();

                myInventory.Add(Console.ReadLine());
                myInventory.Add(Console.ReadLine());
                myInventory.Add(Console.ReadLine());

            }
            else
            {
                Console.WriteLine("Try again");
                
            }



        }

        public void Train(ref string commando, string yourPosition)
        {
            centerText.WriteTextAndCenter("look where you are [inspect]");
            if (commando == "inspect")
            {
                if (yourPosition == position.Train)
                {
                    position.Describe(position.Train);
                    commando = Console.ReadLine();
                }
            } 

                    Console.WriteLine("train");
            Console.ReadLine();


        }
    }
}
