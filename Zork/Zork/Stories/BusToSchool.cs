using System;

namespace Zork
{
    public class BusToSchool: Stories
    {
        public BusToSchool(CharacterIs character)
        {

            Name = "Going from Bus to School";

            if (character==CharacterIs.Ahmad)
            {
                Bio = "You enter the bus. Ticket please";
                      /*"Use buscard" +
                      "inspect{The bus is filled with people, no seats available}" +

                      "exit{You make your way to the exit}"*/;

            }
            else if (character == CharacterIs.Mimmi)
            {
                Bio = "You enter the bus and take your seat in the back, claiming your territory";
                      /*"inspect{there are but a few people here}" +
                      ""*/;
            }
            else if (character == CharacterIs.Markus)
            {
                Bio = "You enter the bus and greet the driver politely";
                //"inspect{ The bus is filled with people, no seats available}";

            }
            
        }

    }
}
