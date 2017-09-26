namespace Zork
{
    public class HomeToTrain : Stories
    {
        public HomeToTrain(CharacterIs character)
        {
            Name = "Going from Home to Train";
            Bio =
                "{0} exits the appartment and starts walking towards the train, with a feeling that something is missing... as always "; //, CharacterName;

            if (character == CharacterIs.Ahmad)
            {
                Bio =
                    "You start walking straight towards the train, with a feeling that something is missing... as always.  ";

/* [Sound the Wakeup Alarm] [Sleep]
 * while loop, if wakeup !=0{"You snoozed once more"}else{"You woke up but still groggy"}
 
   [inspect] [pick] [exit]
   If inspect{" You see your stuff lying on the table, you should maybe take them with you"}*/


            }
        }
    }
}
