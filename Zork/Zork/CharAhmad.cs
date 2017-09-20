using System.Runtime.InteropServices;

namespace Zork
{
    public class CharAhmad : Player
    {
        Inventory inventory = new Inventory();

        public CharAhmad()
        {
            this.Bio = "Ahmad är bäst";
            this.Character = CharacterIs.Ahmad;
        }
    }
}