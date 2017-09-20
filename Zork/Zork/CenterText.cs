using System;

namespace Zork
{
    public class CenterText
    {
        public void WriteTextAndCenter(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }

        public string ReadTextAndCenter(int lenght = 1)
        {
            Console.SetCursorPosition((Console.WindowWidth - lenght) / 2, Console.CursorTop);
            return Console.ReadLine();
        }
    }
}
