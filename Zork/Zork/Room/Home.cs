using System;

namespace Zork
{
    public class Home : Room
    {
        public Home(CharacterIs character)
        {

            Name = "Home";
            isLocked = false;


            if (character == CharacterIs.Ahmad)
            {
                Bio = "BEEEB!!! BEEEP!!! BEEEB!!! BEEEP!!!" +
                      "Ugh! That damn alarm... SnOoooOooZZzzz..\n" +
                      "";
      
            }
            else if (character == CharacterIs.Mimmi)
            {
                Bio =
                    "You wake up! Everything is ready and in its place, " +
                    "you shut the alarm off before it starts ringing.";

            }
            else if(character==CharacterIs.Markus)
            {
                Bio = "Birds are chirping, the smell of lotus " +
                      "flowers enters the room as you breate your first morning breath.";

            }
            
            SmartPhone smartPhone = new SmartPhone();
            BusCardEmpty busCardEmpty = new BusCardEmpty();
            Food food = new Food();
            Keys keys = new Keys();
            Money money = new Money();

            itemsList.Add(smartPhone);
            itemsList.Add(busCardEmpty);
            itemsList.Add(food);
            itemsList.Add(keys);
            itemsList.Add(money);
            ;
            //Skapar exits i rummet
            ExitWithDescription.Add("door", "To be able to get to school you need to exit door");
            ExitWithDescription.Add("bed", "If you go to bed you may never wake up!");

        }
    }
}

   

