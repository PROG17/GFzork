﻿using System.Security.Cryptography.X509Certificates;

namespace Zork
{
    public class School:Room
        {
        public School()
        {
            Name = "School";
            //Bio = "You approach the door the school. " +
            //      "Hope you brought all your items you need for school...";

            Bio = "You are inside the school and are getting ready for the lecture" +
                  "Did you bring everything you need to get trough school?" +
                  "Last chance now!";
            isLocked = true;

            Coffe coffe = new Coffe();
            Food food = new Food();
            itemsList.Add(coffe);
            itemsList.Add(food);
            //ExitWithDescription.Add("door", "To be able to win the game you " +
            //                                "need unlock the door to the school and exit the door");
            ExitWithDescription.Add("door", "To be able to win the you " +
                                            "need exit the door to the classroom");


        }
    }
}

   

