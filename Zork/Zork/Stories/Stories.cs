using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class Stories: ContainerForBasicInfo
    {
        // Skapa dict i dict!!
        Dictionary<Player, Dictionary<Room, List<Stories>>> storiesDictionary = new Dictionary<Player, Dictionary<Room, List<Stories>>>();

        public List<string> myInventory = new List<string>();

        
        public void CreateStories()
        { 
            CharAhmad charAhmad = new CharAhmad();
            Room room = new Room();

            List<Stories> storiesListForAhmad = new List<Stories>();
            Dictionary<Room, List<Stories>> roomDictionary = new Dictionary<Room, List<Stories>>();
            

            storiesDictionary.Add(charAhmad, roomDictionary);
        }


        CenterText centerText = new CenterText();
        Room position = new Room();


        // MARK: Re-do!
        public void Home(ref string commando, ref string yourPosition)
        {
            if (commando == "inspect")
            {
                //if (yourPosition == position.Home)
                //{
                //    position.Describe(position.Home);
                //    commando = Console.ReadLine();

                //    if (commando == "exit")
                //    {
                //        commando = "exit";
                //        yourPosition = position.Train;

                //    }

                //}
               
            }
            
           
        
            else if (commando == "pick")
            {
                Console.WriteLine("Pick 3 items");

               
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
                //if (yourPosition == position.Train)
                //{
                //    position.Describe(position.Train);
                //    commando = Console.ReadLine();
                //}
            } 

                    Console.WriteLine("train");
            Console.ReadLine();


        }

        public void Story(ref Stories story)
        {
            centerText.WriteTextAndCenter(story.Bio);

        }
    }
}
