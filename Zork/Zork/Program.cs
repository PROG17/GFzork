using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaration
            var charMimmi = new CharMimmi();
            var charMarkus = new CharMarkus();
            var charAhmad = new CharAhmad();
            Player chosenCharacter = null;
            Play game = new Play();

           

            //Title Screen
            Console.WriteLine("\n\n\n\n");
            WriteTextAndCenter("Welcome to Travel Adventure");
            WriteTextAndCenter("Choose your character bio\n\n");
            WriteTextAndCenter("Character (1)");
            WriteTextAndCenter(charMimmi.Bio + "\n");
            WriteTextAndCenter("Character (2)");
            WriteTextAndCenter(charMarkus.Bio + "\n");
            WriteTextAndCenter("Character (3)");
            WriteTextAndCenter(charAhmad.Bio + "\n");

            //Väljer story att gå efter
            int charChoice;
            while (true)
            {
                if (int.TryParse(ReadTextAndCenter(), out charChoice))
                {
                    if (charChoice == 1) chosenCharacter = charMimmi;
                    if (charChoice == 2) chosenCharacter = charMarkus;
                    if (charChoice == 3) chosenCharacter = charAhmad;
                    if (charChoice != 1 && charChoice != 2 && charChoice != 3)
                    {
                        WriteTextAndCenter("Try a number between 1-3!");
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
            WriteTextAndCenter("Name your character");
            string name = ReadTextAndCenter(5);
            chosenCharacter.Name = name;

            Console.Clear();

            //Console.Write(MyString.PadLeft(20, '-') + Markus.PadLeft(20, '-'));

            game.Playing(charChoice);

            Console.ReadLine();   
        }

        private static void WriteTextAndCenter(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }

        private static string ReadTextAndCenter(int lenght = 1)
        {
            Console.SetCursorPosition((Console.WindowWidth - lenght) / 2, Console.CursorTop);
            return Console.ReadLine();
        }

    }
}
