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

            //Title Screen
            Console.WriteLine("\n\n\n\n");
            WriteTextAndCenter("Welcome to Travel Adventure");
            WriteTextAndCenter("Choose a your character bio\n\n");
            WriteTextAndCenter("Character 1");
            WriteTextAndCenter(Mimmi.Bio+"\n");
            WriteTextAndCenter("Character 2");
            WriteTextAndCenter(Markus.Bio+"\n");
            WriteTextAndCenter("Character 3");
            WriteTextAndCenter(Ahmad.Bio+"\n");
            
            string charChoice = ReadTextAndCenter();

            Console.Clear();
            Console.WriteLine("\n\n\n");
            WriteTextAndCenter("Name your character");
            string namn = Console.ReadLine();
            Console.Clear();

            //Console.Write(MyString.PadLeft(20, '-') + Markus.PadLeft(20, '-'));


            Console.ReadLine();
        }

        private static void WriteTextAndCenter(string text) {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }

        private static string ReadTextAndCenter()
        {
            Console.SetCursorPosition((Console.WindowWidth-1) / 2, Console.CursorTop);
            return Console.ReadLine();
        }

    }
}
