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
        private int initialNumberOfBacteria = 20;
        private int currentNumberOfBactiera; 

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
            ListOfEndingTexts.Add("Congratulations! You won! \n \t Press Enter to continue");
            ListOfEndingTexts.Add("You lost! Bacteria started mutating! \n \t Press Enter to continue");

            InitializeGame(window);
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

                if(Keyboard.IsKeyPressed(Keyboard.Key.Return))
                {
                    InitializeGame(window); 
                }

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

        private void CreateBacterias(uint maxX, uint maxY)
        {
            for(int i=0; i< initialNumberOfBacteria; i++)
            {
                ListOfBacteria.Add(new Bacteria(pathToBacteriaTexture,(int)maxX,(int)maxY)); 
            }
        }

        private void CheckIfPillCollectedBacteria()
        {
            for (int i = 0; i < currentNumberOfBactiera; i++)
            {
              if(ListOfBacteria[i].GetBoundingBox().Intersects(Pill.GetBoundingBox()))
                {
                    ListOfBacteria.RemoveAt(i);
                    currentNumberOfBactiera--; 
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
            if (currentNumberOfBactiera <= 0)
            {
                State = GameState.Win;
                EndingText.DisplayedString = ListOfEndingTexts[0]; 
            }
        }

        private void CheckLoseConditions()
        {
            if(Timer.GetRemainingTime() <= 0 && currentNumberOfBactiera > 0)
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

        private void InitializeGame(RenderWindow window)
        {
            Pill = new Pill(pathToPillTexture, new SFML.System.Vector2f(window.Size.X, window.Size.Y));
            CreateBacterias(window.Size.X, window.Size.Y);
            currentNumberOfBactiera = initialNumberOfBacteria; 
            Font = new Font(pathToFont);
            Timer = new Timer(Font, new SFML.System.Vector2f(window.Size.X, window.Size.Y));
            State = GameState.Running;
            GameLoop(window);
        }
        
    }
}
