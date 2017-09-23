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
    }
}

   

