﻿namespace Zork
{
    public class BusToSchool: Stories
    {
        public BusToSchool(CharacterIs character)
        {

            Name = "Going from Bus to School";

            if (character==CharacterIs.Ahmad)
            {
                Bio = "You enter the bus and its full of people." +
                      "inspect{The bus is filled with people,}" +
                      "";
            }
            else if (character == CharacterIs.Mimmi)
            { 
                Bio =
                    "It has been an eventful morning, " +
                    "You take a seat next to an older lady trying to catch a moment of rest?";
            } 
            else if (character == CharacterIs.Markus)
            {
                
            }





        }

    }
}
