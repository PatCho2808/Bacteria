using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace Bacteria
{
    class Menu : Drawable 
    {
        private List<String> ListOfMenuOptions = new List<string>();
        private Font Font;
        private List<Text> ListOfMenuTexts = new List<Text>(); 

        public Menu(Font newFont, SFML.System.Vector2f WindowSize)
        {
            Font = newFont;

            ListOfMenuOptions.Add("Play");
            ListOfMenuOptions.Add("Exit");

            SetTexts(WindowSize); 
        }

        private void SetTexts(SFML.System.Vector2f WindowSize)
        {
            ListOfMenuOptions.ForEach(el => ListOfMenuTexts.Add(new Text(el, Font)));

            for (int i = 0; i < ListOfMenuTexts.Count(); i++)
            {
                ListOfMenuTexts[i].Position = new SFML.System.Vector2f(WindowSize.X / 2 - ListOfMenuTexts[i].GetGlobalBounds().Width / 2, WindowSize.Y / ListOfMenuTexts.Count() + i * 100 - 30);
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            ListOfMenuTexts.ForEach(el => el.Draw(target, states));
        }
    }
}
