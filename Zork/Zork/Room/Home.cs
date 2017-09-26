using System;

namespace Zork
{
    public class Home : Room
    {
        public Home(CharacterIs character)
        {

            Name = "Home";

            //"You are at home. " +
            //    "You can choose to go back to [bed] or [exit] through the [door], " +
            //    "but don't forget to pick your items you need for school.";

            if (character == CharacterIs.Ahmad)
            {
                Bio = "BEEEB!!! BEEEP!!! BEEEB!!! BEEEP!!!" +
                      "Ugh! That damn alarm... SnOoooOooZZzzz..\n" +
                      "";
                
                /* [Sound the Wakeup Alarm] [Sleep]
                 * while loop, if wakeup !=0{"You snoozed once more"}else{"You woke up but still groggy"}
                 
                   [inspect] [pick] [exit]
                   If inspect{" You see your stuff lying on the table, you should maybe take them with you"}
                   If exit{"You put on your clothes and exit your house"*/
            } else if (character == CharacterIs.Mimmi)
            {
                Bio = "You wake up! Everything is ready and in its place, you shut the alarm off before it starts ringing."
                      /*"inspect{All your items are neatly placed on the night stand}" +
                      "exit{everything is set, you exit the building"*/;
            }
            else if(character==CharacterIs.Markus)
            {
                Bio = "Birds are chirping, the smell of lotus flowers enters the room as you breate your first morning breath."
                      /*"inspect{your partner has woken up before you and have had your things ready" +
                      "-What do you need to take with you today, she says while hands you your daily items}" +
                      "exit{your partner gives you a kiss on your cheek, sprays some rose water on you and you are off}"*/;
            }



            
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
            //Skapar exits i rummet
            ExitWithDescription.Add("door", "Descriptionn");
            ExitWithDescription.Add("Bed", Name);

        }
    }
}

   

