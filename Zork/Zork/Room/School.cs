using System.Security.Cryptography.X509Certificates;

namespace Zork
{
    public class School:Room
        {
        public School()
        {
            Name = "School";
            Bio = "You approach the door the school.\n open door or use your key" +
                  "if keys are lost and is late (cant open door and dies), if missing keys but in time (Option to wait for other students to open door(but becomes late))" +
                  "if keys are present, open door and win. ?";

            Coffe coffe = new Coffe();
            Food food = new Food();

            itemsList.Add(coffe);
            itemsList.Add(food);

        }
    }
}

   

