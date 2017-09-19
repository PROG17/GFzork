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
            //Menu
            Player mimmi = new Player(CharacterIs.Mimmi);
            Player markus = new Player(CharacterIs.Markus);
            Player ahmad = new Player(CharacterIs.Ahmad);
            Player chosenCharacter;

            //Title Screen
            Console.WriteLine("\n\n\n\n");
            WriteTextAndCenter("Welcome to Travel Adventure");
            WriteTextAndCenter("Choose a your character bio\n\n");
            WriteTextAndCenter("Character (1)");
            WriteTextAndCenter(mimmi.Bio + "\n");
            WriteTextAndCenter("Character (2)");
            WriteTextAndCenter(markus.Bio + "\n");
            WriteTextAndCenter("Character (3)");
            WriteTextAndCenter(ahmad.Bio + "\n");

            //Väljer story att gå efter
            int charChoice;
            while (true)
            {
                if (int.TryParse(ReadTextAndCenter(), out charChoice))
                {
                    if (charChoice == 1) chosenCharacter = new Player(CharacterIs.Mimmi);
                    if (charChoice == 2) chosenCharacter = new Player(CharacterIs.Markus);
                    if (charChoice == 3) chosenCharacter = new Player(CharacterIs.Ahmad);
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
            string namn = Console.ReadLine();
            Console.Clear();

            //Console.Write(MyString.PadLeft(20, '-') + Markus.PadLeft(20, '-'));


            Console.ReadLine();
        }

        private static void WriteTextAndCenter(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }

        private static string ReadTextAndCenter()
        {
            Console.SetCursorPosition((Console.WindowWidth - 1) / 2, Console.CursorTop);
            return Console.ReadLine();
        }

    }
}
