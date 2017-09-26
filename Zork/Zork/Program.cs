using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //Declaration
            var charMimmi = new CharMimmi();
            var charMarkus = new CharMarkus();
            var charAhmad = new CharAhmad();
            Player chosenCharacter = null;
            Play game = new Play();
            CenterText centerText = new CenterText();
            

            //Title Screen
            Console.WriteLine("\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            centerText.WriteTextAndCenter("Welcome to Travel Adventure\n");
            Console.ForegroundColor = ConsoleColor.Green;
            centerText.WriteTextAndCenter("Your mission is to get to school!\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            centerText.WriteTextAndCenter("But first, choose your character bio\n\n");
            centerText.WriteTextAndCenter("Character (1)");
            centerText.WriteTextAndCenter(charMimmi.Bio + "\n");
            centerText.WriteTextAndCenter("Character (2)");
            centerText.WriteTextAndCenter(charMarkus.Bio + "\n");
            centerText.WriteTextAndCenter("Character (3)");
            centerText.WriteTextAndCenter(charAhmad.Bio + "\n");


            //Väljer story att gå efter
            int charChoice;
            while (true)
            {
                if (int.TryParse(centerText.ReadTextAndCenter(), out charChoice))
                {
                    if (charChoice == 1) chosenCharacter = charMimmi;
                    if (charChoice == 2) chosenCharacter = charMarkus;
                    if (charChoice == 3) chosenCharacter = charAhmad;
                    if (charChoice != 1 && charChoice != 2 && charChoice != 3)
                    {
                        centerText.WriteTextAndCenter("Try a number between 1-3!");
                        continue;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Try with numbers instead");
                    
                }
            }

            Console.Clear();
            Console.WriteLine("\n\n\n");
            centerText.WriteTextAndCenter("Name your character");
            string name = centerText.ReadTextAndCenter(5);
            chosenCharacter.Name = name;

            Console.Clear();

            centerText.WriteTextAndCenter("Welcome " + chosenCharacter.Name + "!");

            game.Playing(chosenCharacter);

            Console.ReadLine();   
        }


    }
}
