using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Bacteria
{
    class EndindText : TextObject
    {

        private List<string> ListOfEndingTexts = new List<string>();
        
        
        public EndindText(Font newFont, SFML.System.Vector2f WindowSize) : base(newFont,WindowSize)
        {
            ListOfEndingTexts.Add("Congratulations! You won! \n \t Press Enter to continue");
            ListOfEndingTexts.Add("You lost! Bacteria started mutating! \n \t Press Enter to continue");
            Text.Scale = new SFML.System.Vector2f(.5f, .5f);
            Text.Style = Text.Styles.Bold;
        }

        public void SetPosition()
        {
            Text.Origin = new SFML.System.Vector2f(Text.GetGlobalBounds().Width / 2, Text.GetGlobalBounds().Height / 2);
            Text.Position = new SFML.System.Vector2f(windowWidth / 2 - 100, windowHeight / 2);
        }

        public void SetString(bool win)
        {
            Text.DisplayedString =  win ? ListOfEndingTexts[0] : ListOfEndingTexts[1];
            SetPosition();
        }
    }
}
