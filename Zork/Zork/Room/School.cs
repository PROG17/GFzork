using System.Security.Cryptography.X509Certificates;

namespace Zork
{
    public class School:Room
        {
        public School()
        {
            Name = "School";
            Bio = "You are inside the school and are getting ready for the lecture " +
                  "Did you bring everything you need to get trough school? " +
                  "Last chance now!";
            isLocked = false;

            Coffe coffe = new Coffe();
            Food food = new Food();
            itemsList.Add(coffe);
            itemsList.Add(food);

            ExitWithDescription.Add("door", "To be able to win the game you " +
                                            "need exit the door to the classroom");


        }
    }
}

   

