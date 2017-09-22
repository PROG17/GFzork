using System;

namespace Zork
{
    public class Cab: Room, IRoom
    {
        public Cab()
        {
            base.Name = "Cab";
            base.Bio = "Your'e inside a cab, in the backseat behind the driver. \n" +
                       "Suddenly you realise that someone has dropped a wallet between the seats. \n" +
                           "Soon you will be att your destianation.... \n" +
                             "What will you do with the wallet? (get) or (drop)";


        }


        
    }
}