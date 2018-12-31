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
        private bool menuOpened;

        private Sprite Sprite;
        private Texture Texture;
        private string PathToBackgroundTileTexture = "G:\\Documents\\VisualStudioProjects\\Bacteria\\Content\\BackgroundMenu.png";



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
            menuOpened = true;

            SetBackground((int)window.Size.X, (int)window.Size.Y);
            Console.WriteLine("Menu constructor");
            MenuLoop(window);
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
            if(menuOpened)
            {
                if (e.Code == Keyboard.Key.Up)
                {
                    MoveUp();
                }

                if (e.Code == Keyboard.Key.Down)
                {
                    MoveDown();
                }

                if (e.Code == Keyboard.Key.Return)
                {
                    RenderWindow window = (RenderWindow)sender;
                    Console.WriteLine("Execute correct button"); 
                    ExecuteCorrectButton(window);
                }

                if (e.Code == Keyboard.Key.Escape)
                {
                    RenderWindow window = (RenderWindow)sender;
                    window.Close();
                }
            }
           
        }

        public void MenuLoop(RenderWindow window)
        {
            while (menuOpened)
            {
                window.DispatchEvents();
                window.Clear(new Color(34, 37, 47));
                window.Draw(this);
                window.Display();
            }
        }

        private void ExecuteCorrectButton(RenderWindow window)
        {
            switch (ListOfMenuTexts[checkedOption].DisplayedString)
            {
                case "Play":
                    menuOpened = false;
                    break;
                case "Exit":
                    window.Close();
                    break;
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            Sprite.Draw(target, states);
            ListOfMenuTexts.ForEach(el => el.Draw(target, states));
            
        }

        private void SetBackground(int x, int y)
        {
            Texture = new Texture(PathToBackgroundTileTexture);
            Texture.Repeated = true;
            Sprite = new Sprite(Texture, new IntRect(new SFML.System.Vector2i(0, 0), new SFML.System.Vector2i(x/ 4, y/ 4)));
            Sprite.Scale = new SFML.System.Vector2f(4, 4);
        }
    }
}
