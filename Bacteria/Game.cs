using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace Bacteria
{
    class Game
    {
        private string pathToPillTexture = "F:\\Documents\\VisualStudioProjects\\Bacteria\\Content\\Pill.png";
        private string pathToBacteriaTexture = "F:\\Documents\\VisualStudioProjects\\Bacteria\\Content\\Bacteria.png";
        private Pill Pill { get; set; }
        private List<Bacteria> ListOfBacteria = new List<Bacteria>();
        private int numberOfBacteria = 20; 

        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        public Game(uint x, uint y)
        {
            RenderWindow window = new RenderWindow(new VideoMode(x, y), "Bacteria", SFML.Window.Styles.Close);
            window.Closed += new EventHandler(OnClose);
            Pill = new Pill(pathToPillTexture, new SFML.System.Vector2f(x,y));
            CreateBacterias((int)x,(int)y); 

            GameLoop(window);
        }

        public void GameLoop(RenderWindow window)
        {
            while (window.IsOpen)
            {
                window.DispatchEvents();
                MovePill();
                window.Clear(new Color(34, 37, 47));
                Draw(window); 
                window.Display(); 
            }
        }

        private void Draw(RenderWindow window)
        {
            Pill.Draw(window, RenderStates.Default);
            //ListOfBacteria.ForEach(el=>el.Draw(window, RenderStates.Default));
            for (int i = 0; i < numberOfBacteria; i++)
            {
                ListOfBacteria[i].Draw(window, RenderStates.Default);
            }
        }

        private void MovePill()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                Pill.MoveUp();
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                Pill.MoveDown();
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                Pill.MoveRight();
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                Pill.MoveLeft();
            }
        }

        private void CreateBacterias(int maxX, int maxY)
        {
            for(int i=0; i<numberOfBacteria; i++)
            {
                ListOfBacteria.Add(new Bacteria(pathToBacteriaTexture,maxX,maxY)); 
            }
        }

        
    }
}
