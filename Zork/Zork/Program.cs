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
            Player Mimmi = new Player();
            Player Markus = new Player();
            Player Ahmad = new Player();

            Mimmi.Bio = "mimmi";
            Markus.Bio = "markus";
            Ahmad.Bio = "ahmad";


            Console.WriteLine("Välkommen till zork\nVälj en spelare: ");
            Console.WriteLine(Mimmi.Bio);
            Console.WriteLine(Markus.Bio);
            Console.WriteLine(Ahmad.Bio);


            //Console.Write(MyString.PadLeft(20, '-') + Markus.PadLeft(20, '-'));


            Console.ReadLine();
        }
    }
}
