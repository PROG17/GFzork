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
                           "Soon you will be att your destianation.... \n" +
                             "What will you do with the wallet? (get) or (drop)";

            SmartPhone smartPhone = new SmartPhone();

            itemsList.Add(smartPhone);

            ExitWithDescription.Add("door", "cab Descriptionn");
        }


        
    }

}