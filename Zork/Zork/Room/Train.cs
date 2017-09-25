using System.Runtime.Serialization.Formatters;

namespace Zork
{
    public class Train: Room
    {
        public Train()
        {
            Name = "Train";
            Bio = "While on the train {0} finds a newspaper on the seat. Pick it up to read?\n" +
                  /*if(commando==pick)*/"{0} turns to the last page and finds a sudoku puzzle, nice.. better practice on this to make sure the next assignmet will go smoothley!!" +
                  /*If(commando==skip)*/"{0} uses the newspaper as an asswarmer." +
                  "Inspect the surrounding? Jump off the train? Wait until Odenplan? Check your inventory?" ;

            SmartPhone smartPhone = new SmartPhone();
            Money money = new Money();

            itemsList.Add(smartPhone);
            itemsList.Add(money);
        }
    }
}

   

