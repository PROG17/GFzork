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

            Console.WriteLine("Välkommen till zork\nVälj en spelare: ");
            Console.WriteLine(mimmi.Bio);
            Console.WriteLine(markus.Bio);
            Console.WriteLine(ahmad.Bio);


            Console.ReadLine();
        }
    }
}
