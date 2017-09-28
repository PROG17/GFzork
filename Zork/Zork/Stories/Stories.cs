using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public abstract class Stories: ContainerForBasicInfo
    {
        public void PrintStory(ref Stories story)
        {
            CenterText centerText = new CenterText();
            centerText.WriteTextAndCenter(story.Bio);
        }
    }
}
