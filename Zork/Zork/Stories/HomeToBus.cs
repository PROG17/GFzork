﻿namespace Zork
{
    public class HomeToBus : Stories
    {
        public HomeToBus(CharacterIs character)
        {
            Name = "Going from Home to Train";
            string nextRoom = "To be able to enter the train or cab you need to unlock the door with an item.";

            if (character == CharacterIs.Ahmad)
            {
                Bio =
                    "You start walking straight towards the train, with a feeling that something is missing... as always."
                    + nextRoom; /* +
                    "If cash less than 60kr you cant enter the station and you miss your train. directed to cab" +
                    "{to train}" +
                    "{to cab}Takes you all the way to school but might get stuck in traffic  ";*/
            }
            else if (character == CharacterIs.Mimmi)
            {
                Bio =
                    "While walking down the street, you are greeted by alot of people with their special handshake. You surely arent alone!"
                    + nextRoom; ;/* +
                      "inspect{You are surrounded by the million programme, the smell of burnt rubber fills the air of the hood.}" +
                      "You should maybe check if you have enough money for the train";*/
            }
            else if (character == CharacterIs.Markus)
            {
                Bio =
                    "When you exit the house you feel how life caress your face, you have plenty of time to catch your train."
                    + nextRoom; ;
                /*"inspect{'Sun is shining, over the rainbow... I want you to know... Im a rainbow too'.-Oh right..almost forgot to check if i am carrying enough money}" +
                      "";*/
            }
        }
    }
}