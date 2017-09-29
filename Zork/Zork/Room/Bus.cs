namespace Zork
{
    public class Bus : Room
    {
        public Bus()
        {
            Name = "Bus";
            Bio = "The bus is packed with people and you have to queese in";
            ExitWithDescription.Add("door", "To be able to get off the bus you need to exit door");
            isLocked = false;
        }        
    }
}

   

