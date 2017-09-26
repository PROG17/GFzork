using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class Stories: ContainerForBasicInfo
    {

        public List<string> myInventory = new List<string>();
        CenterText centerText = new CenterText();

        public void Story(ref Stories story)
        {

            centerText.WriteTextAndCenter(story.Bio);

        }
    }
}
