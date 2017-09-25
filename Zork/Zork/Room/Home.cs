namespace Zork
{
    public class Home : Room
    {


        public Home()
        {
            Name = "Home";
            
            Bio = "You are at home. " +
                  "You can choose to go back to [bed] or [exit] through the [door], " +
                  "but don't forget to pick your items you need for school.";
            
            SmartPhone smartPhone = new SmartPhone();
            BusCard busCard = new BusCard();
            Coffe coffe = new Coffe();
            Food food = new Food();
            Keys keys = new Keys();
            Money money = new Money();

            itemsList.Add(smartPhone);
            itemsList.Add(busCard);
            itemsList.Add(coffe);
            itemsList.Add(food);
            itemsList.Add(keys);
            itemsList.Add(money);
            ;

        }
    }
}

   

