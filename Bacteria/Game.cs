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
        private List<string> ListOfEndingTexts = new List<string>();
        private Text EndingText = new Text(); 

        public Game(uint x, uint y)
        {
            RenderWindow window = new RenderWindow(new VideoMode(x, y), "Bacteria", SFML.Window.Styles.Close);
            window.Closed += new EventHandler(OnClose);
            Pill = new Pill(pathToPillTexture, new SFML.System.Vector2f(x,y));
            CreateBacterias((int)x,(int)y);
            Font = new Font(pathToFont);
            Timer = new Timer(Font, new SFML.System.Vector2f(x, y));
            State = GameState.Running;
            ListOfEndingTexts.Add("Congratulations! You won! \n Press Enter to continue");
            ListOfEndingTexts.Add("You lose! Bacteria started mutating! \n Press Enter to continue");

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

            SetEndingText(window.Size.X,window.Size.Y); 

            while(State == GameState.Win || State == GameState.Lose)
            {
                window.DispatchEvents();
                window.Clear(new Color(34, 37, 47));
                Console.WriteLine("win or lose"); 
                window.Draw(EndingText); 
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
                State = GameState.Win;
                EndingText.DisplayedString = ListOfEndingTexts[0]; 
            }
        }

        private void CheckLoseConditions()
        {
            if(Timer.GetRemainingTime() <= 0 && numberOfBacteria > 0)
            {
                State = GameState.Lose;
                EndingText.DisplayedString = ListOfEndingTexts[1];
            }
        }

        private void SetEndingText(uint x, uint y)
        {
            EndingText.Font = Font; 
            EndingText.Origin = new SFML.System.Vector2f(EndingText.GetGlobalBounds().Width / 2, EndingText.GetGlobalBounds().Height/ 2);
            EndingText.Position = new SFML.System.Vector2f(x / 2, y / 2);
            EndingText.Scale = new SFML.System.Vector2f(.5f, .5f);
            EndingText.Style = Text.Styles.Bold; 

        }
        
    }
}
