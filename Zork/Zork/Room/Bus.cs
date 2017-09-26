namespace Zork
{
    public class Bus : Room
    {
        public Bus()
        {
            Name = "Bus";
            Bio = "The bus is packed with people"/* +
                  "Inspect the area, to find that there is an empty seat close to the door" +
                  "as you approach the seat you spot an older lady. [Sit] & [Give her your seat]." +
                  "if sit is chosen, you get to rest and check your inventory but you wont be the first to exit the bus"*/;
            isLocked = true;
            
            Money money = new Money();
            itemsList.Add(money);
        }


        
    }
}

   

