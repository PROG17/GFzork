using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    
    public class Room : ContainerForBasicInfo, IRoom
    {


        public void Inspect(Room room)
        {
            Console.WriteLine(room.Bio);

        }

        
        
        public void Position(ref Room room)
        {
            if (room.Name == "Home") { room = new Train(); return; }
            if (room.Name == "Train") { room = new Bus(); return; }
            if (room.Name == "Bus") { room = new School(); return; }
            


        }

    }
}

   

