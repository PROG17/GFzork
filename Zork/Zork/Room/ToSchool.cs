using System;

namespace Zork
{
    public class ToSchool: Room
    {
        public ToSchool()
        {

            Name = "In front of the School";
            Bio = "You are walking directly to the door.";
            
            ExitWithDescription.Add("door", "This is the main door to the school");
            ExitWithDescription.Add("home", "Forgot something? Do you need to go home?");

        }

    }
}
