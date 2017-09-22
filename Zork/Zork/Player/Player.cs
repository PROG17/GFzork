using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{

    public class Player: ContainerForBasicInfo
    {
        public CharacterIs Character { get; protected set; }
        public List<Inventory> inventoryList = new List<Inventory>();
        
    }


    public enum CharacterIs
    {
        Mimmi,
        Markus,
        Ahmad
    }
}
