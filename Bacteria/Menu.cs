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
        private int checkedOption;
        private int maxOptions;

        

        public Menu(Font newFont, RenderWindow window)
        {
            Font = newFont;

            ListOfMenuOptions.Add("Play");
            ListOfMenuOptions.Add("Exit");

            SetTexts(new SFML.System.Vector2f(window.Size.X,window.Size.Y));

            maxOptions = ListOfMenuTexts.Count();
            checkedOption = 0;
            ListOfMenuTexts[checkedOption].Color = new Color(175, 14, 27);

            window.KeyReleased += OnKeyReleased;

        }

        private void SetTexts(SFML.System.Vector2f WindowSize)
        {
            ListOfMenuOptions.ForEach(el => ListOfMenuTexts.Add(new Text(el, Font)));

            for (int i = 0; i < ListOfMenuTexts.Count(); i++)
            {
                ListOfMenuTexts[i].Position = new SFML.System.Vector2f(WindowSize.X / 2 - ListOfMenuTexts[i].GetGlobalBounds().Width / 2, WindowSize.Y / ListOfMenuTexts.Count() + i * 100 - 30);
            }
        }

        public void MoveUp()
        {
            ListOfMenuTexts[checkedOption].Color = new Color(255, 255, 255);
            checkedOption--;
            if (checkedOption < 0) checkedOption = ListOfMenuTexts.Count() - 1;
            ListOfMenuTexts[checkedOption].Color = new Color(175, 14, 27);
        }

        public void MoveDown()
        {
            ListOfMenuTexts[checkedOption].Color = new Color(255, 255, 255);
            checkedOption++;
            if (checkedOption > ListOfMenuTexts.Count() - 1) checkedOption = 0;
            ListOfMenuTexts[checkedOption].Color = new Color(175, 14, 27);
        }

        public void OnKeyReleased(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Up)
            {
                MoveUp(); 
            }

            if (e.Code == Keyboard.Key.Down)
            {
                MoveDown();
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            ListOfMenuTexts.ForEach(el => el.Draw(target, states));
        }
    }
}
