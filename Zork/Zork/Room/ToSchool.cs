using System;

namespace Zork
{
    public class ToSchool: Room
    {
        public ToSchool(CharacterIs character)
        {

            Name = "In front of the School";
            Bio = "You are walking directly to the door.";
            

            ExitWithDescription.Add("door", "This is the main door to the school");
            //ExitWithDescription.Add("window", "This is a window that actually seems to be open " +
            //                                  "an exit to enter the school " +
            //                                  "if you did remember to pick up that big rock?");


        }

    }
}
