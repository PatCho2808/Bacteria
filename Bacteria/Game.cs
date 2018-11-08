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
        private string pathToFont = "F:\\Documents\\VisualStudioProjects\\Bacteria\\Content\\PressStart2P-Regular.ttf";
        private Font Font; 
        private Pill Pill { get; set; }
        private List<Bacteria> ListOfBacteria = new List<Bacteria>();
        private int numberOfBacteria = 20; 
        private Timer Timer;
        enum GameState
        {
            Menu, Running, Win, Lose
        }
        private GameState State;

        public Game(uint x, uint y)
        {
            RenderWindow window = new RenderWindow(new VideoMode(x, y), "Bacteria", SFML.Window.Styles.Close);
            window.Closed += new EventHandler(OnClose);
            Pill = new Pill(pathToPillTexture, new SFML.System.Vector2f(x,y));
            CreateBacterias((int)x,(int)y);
            Font = new Font(pathToFont);
            Timer = new Timer(Font, new SFML.System.Vector2f(x, y));
            State = GameState.Running; 

            GameLoop(window);
        }

        public void GameLoop(RenderWindow window)
        {
            while (State == GameState.Running)
            {
                window.DispatchEvents();
                window.Clear(new Color(34, 37, 47));
                Update(window);
                window.Display(); 
            }
        }

        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        private void Update(RenderWindow window)
        {
            Pill.Update();
            Draw(window);
            CheckIfPillCollectedBacteria();
            Timer.Update();
            UpdateState(); 
        }

        private void Draw(RenderWindow window)
        {
            Pill.Draw(window, RenderStates.Default);
            ListOfBacteria.ForEach(el=>el.Draw(window, RenderStates.Default));
            Timer.Draw(window, RenderStates.Default);
        }

        private void CreateBacterias(int maxX, int maxY)
        {
            for(int i=0; i<numberOfBacteria; i++)
            {
                ListOfBacteria.Add(new Bacteria(pathToBacteriaTexture,maxX,maxY)); 
            }
        }

        private void CheckIfPillCollectedBacteria()
        {
            for (int i = 0; i < numberOfBacteria; i++)
            {
              if(ListOfBacteria[i].GetBoundingBox().Intersects(Pill.GetBoundingBox()))
                {
                    ListOfBacteria.RemoveAt(i);
                    numberOfBacteria--; 
                }
            }
        }

        
        private void UpdateState()
        {
            CheckLoseConditions();
            CheckWinConditions();                
        }

        private void CheckWinConditions()
        {
            if (numberOfBacteria <= 0)
            {
                Console.WriteLine("u win ");
                State = GameState.Win;
            }
        }

        private void CheckLoseConditions()
        {
            if(Timer.GetRemainingTime() <= 0 && numberOfBacteria > 0)
            {
                Console.WriteLine("u lost ");
                State = GameState.Lose;
            }
        }
        
    }
}
