using System;

namespace Zork
{
    public class Cab: Room
    {
        public Cab(CharacterIs character)
        {
            Name = "Cab";
            Bio = "Your'e inside a cab, in the backseat behind the driver. \n" +
                  "Suddenly you realise that someone has dropped a wallet between the seats. \n" +
                  "Soon you will be att your destination.... \n";

            Wallet wallet = new Wallet();

            itemsList.Add(wallet);
            isLocked = false;

            ExitWithDescription.Add("door", "To be able to get off the cab you need to exit door");
        }


        
    }

}