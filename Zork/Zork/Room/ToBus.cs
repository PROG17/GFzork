namespace Zork
{
    public class ToBus : Room
    {
        public ToBus(CharacterIs character)
        {
            Name = "Going from Home to Bus";

            if (character == CharacterIs.Ahmad)
            {
                Bio =
                    "You start walking straight towards the bud, " +
                    "with a feeling that something is missing... as always.";
              
            }
            else if (character == CharacterIs.Mimmi)
            {
                Bio =
                    "While walking down the street, " +
                    "you are greeted by alot of people with their special handshake. " +
                    "You surely aren't alone!"; ;
            }
            else if (character == CharacterIs.Markus)
            {
                Bio =
                    "When you exit the house you feel how life caress your face, " +
                    "you have plenty of time to catch your bus."; ;
            }

            ExitWithDescription.Add("bus", "To be able to enter you need to have a valid item" +
                                            "that must be used. Otherwise you might need to take an Uber.");
            ExitWithDescription.Add("cab", "If you have a smartphone you can get an Uber right away!");
            Rock rock = new Rock();
            itemsList.Add(rock);

            isLocked = true;

        }
    }
}
