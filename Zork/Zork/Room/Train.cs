//using System.Runtime.Serialization.Formatters;

//namespace Zork
//{
//    public class Train: Room
//    {

//        public Train(CharacterIs character)
//        {
//            Name = "Train";
//            isLocked = true;

//            SmartPhone smartPhone = new SmartPhone();
//            Money money = new Money();

//            itemsList.Add(smartPhone);
//            itemsList.Add(money);

            if (character == CharacterIs.Ahmad)
            {
                Bio = "You enter the train and immediately find a seat further in! \n";/* +
                    "[Inspect] [Jump off the train] [Wait until Odenplan] [Check your inventory]" +
                      "if Inspect{There is a lady sleeping in front of you, and on the seat next to you there is a newspaper"+
                "if(commando==pick)you turn to the last page and find a sudoku puzzle, nice.. better practice on this to make sure the next assignmet will go smoothely!!" +
                    "if jump off train{who in their right mind would jump off the train in mid speed? You died!}" +
                      "if Wait{You put on your earplugs and start listening to some podcast, you should be at Odenplan soon}";*/
            }
            else if(character == CharacterIs.Mimmi)
            {
                Bio = "You enter the train and find an empty row where you can rest undisturbed";
            }
            else if(character==CharacterIs.Markus)
            {
                Bio = "You enter the train, find your way to a seat close to the window, gazing out the window and enjoying the view! ";
            }
            ExitWithDescription.Add("door", "To be able to get off the train you need to exit the door");
        }

//    }

//}
       

   

