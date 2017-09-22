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
        Room room = new Room();




        public void Playing(int player)
        {
            // -----------Markus
            room.CreateStartingPointForRooms();
            Room current;
            current = new Cab();
            Console.WriteLine(current.Name);
            Console.WriteLine(current.Bio);

            if (current is Cab)
            {
                var cab = current as Cab;
                cab.DescribeTest();
            }

            //BaseClass myBaseObject = new BaseClass();
            //DerivedClass myDerivedObject = myBaseObject as DerivedClass;

            //myDerivedObject.MyDerivedProperty = true;


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
                
                

                centerText.WriteTextAndCenter(position.Home);
                while (alive)
                {

                    //Inspect eller välj inventory
                    //Console.WriteLine("look where you are [inspect] | pick your inventory [pick]");
                    //commando = Console.ReadLine();
                    //centerText.WriteTextAndCenter(yourPosition);

                    //Inspect eller välj inventory
                    centerText.WriteTextAndCenter("look where you are [inspect] | pick your inventory [pick]");
                    commando = centerText.ReadTextAndCenter(5);


                    story.Home(ref commando, ref yourPosition);



                    if (commando == "pick")
                    {
                        position.ItemsHome();

                    }
                    else if (commando == "exit"){ story.Train(ref commando, yourPosition); }


                    else
                    {
                        centerText.WriteTextAndCenter("Try again");
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

