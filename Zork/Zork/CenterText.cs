using System;

namespace Zork
{
    public class CenterText
    {
        public void WriteTextAndCenter(string text)
        {
            if (text != null)
            {
                if ((Console.WindowWidth - text.Length) < 0)
                {
                    // Lägg inte texten i mitten om texten är för stor
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
                }
            }
           
            Console.WriteLine(text);
        }

        public string ReadTextAndCenter(int lenght = 1)
        {
            Console.SetCursorPosition((Console.WindowWidth - lenght) / 2, Console.CursorTop);
            return Console.ReadLine().ToLower();
        }
    }
}
