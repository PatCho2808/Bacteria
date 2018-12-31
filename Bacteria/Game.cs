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
        private string pathToBackground = "F:\\Documents\\VisualStudioProjects\\Bacteria\\Content\\BackgroundGame.png";
        private Sprite BackgroundSprite;
        private Texture BackgroundTexture; 
        private Font Font; 
        private Pill Pill { get; set; }
        private List<Bacteria> ListOfBacteria = new List<Bacteria>();
        private int initialNumberOfBacteria;
        private int currentNumberOfBacteria;
        private Menu Menu; 
        

        private LevelTimer Timer;
        enum GameState
        {
            Menu, Running, Win, Lose
        }
        private GameState State;
        private EndindText EndingText;

        private List<LevelBase> ListOfLevels = new List<LevelBase>();
        private int currentLevel;
        private int firstLevel = 0;
        private int currentLevelDuration; 
        

        public Game(uint x, uint y)
        {
            RenderWindow window = new RenderWindow(new VideoMode(x, y), "Bacteria", SFML.Window.Styles.Close);
            window.Closed += new EventHandler(OnClose);
            window.KeyReleased += OnKeyReleased;

            Font = new Font(pathToFont);

            SetBackground();
            SetLevels();

            OpenMenu(window); 
        }

        public void GameLoop(RenderWindow window)
        {
            
            while (State == GameState.Running)
            {
                window.DispatchEvents();
                window.Clear();
                Update(window);
                window.Display(); 
            }

            ClearAfterLevel();

            while (State == GameState.Win || State == GameState.Lose)
            {
                window.DispatchEvents();
                window.Clear();
                window.Draw(BackgroundSprite); 

                EndingText.Draw(window, RenderStates.Default);
                window.Display();
            }
        }

        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        public void OnKeyReleased(object sender, KeyEventArgs e)
        {
            if (State != GameState.Menu && e.Code == Keyboard.Key.Escape)
            {
                ClearAfterLevel();
                RenderWindow window = (RenderWindow)sender;
                OpenMenu(window); 
            }

            if ((State == GameState.Win || State == GameState.Lose) && e.Code == Keyboard.Key.Return)
            {
                RenderWindow window = (RenderWindow)sender;

                if (currentLevel >= ListOfLevels.Count)
                {
                    ClearAfterGame();
                    OpenMenu(window);
                    
                }

                else InitializeGame(window);
            }
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
            window.Draw(BackgroundSprite); 
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
            for (int i = 0; i < currentNumberOfBacteria; i++)
            {
              if(ListOfBacteria[i].GetBoundingBox().Intersects(Pill.GetBoundingBox()))
                {
                    ListOfBacteria.RemoveAt(i);
                    currentNumberOfBacteria--; 
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
            if (currentNumberOfBacteria <= 0)
            {
                OnWin();
            }
        }

        private void CheckLoseConditions()
        {
            if(Timer.GetRemainingTime() <= 0 && currentNumberOfBacteria > 0)
            {
               OnLose(); 
            }
        }

        private void InitializeGame(RenderWindow window)
        {
            Pill = new Pill(pathToPillTexture, new SFML.System.Vector2f(window.Size.X, window.Size.Y));
            SetCurrentLevel();
            Timer = new LevelTimer(Font, new SFML.System.Vector2f(window.Size.X, window.Size.Y), currentLevelDuration);
            CreateBacterias(window.Size.X, window.Size.Y);
            currentNumberOfBacteria = initialNumberOfBacteria;
            EndingText = new EndindText(Font, new SFML.System.Vector2f(window.Size.X, window.Size.Y));
            State = GameState.Running;
            GameLoop(window);
        }
        
        private void ClearAfterLevel()
        {
            ListOfBacteria.Clear();
            currentNumberOfBacteria = 0;
        }

        private void ClearAfterGame()
        {
            ClearAfterLevel();
            ResetLevels();            
        }

        private void OpenMenu(RenderWindow window)
        {
            State = GameState.Menu;
            Menu = null;
            Menu = new Menu(Font, window);

            InitializeGame(window);
        }

        private void SetBackground()
        {
            BackgroundTexture = new Texture(pathToBackground);
            BackgroundSprite = new Sprite(BackgroundTexture);
            BackgroundSprite.Color = new Color(255, 255, 255, 128);
        }

        private void SetLevels()
        {
            ResetLevels(); 
            ListOfLevels.Add(new FirstLevel());
            ListOfLevels.Add(new SecondLevel());
            ListOfLevels.Add(new ThirdLevel());
        }

        private void ResetLevels()
        {
            currentLevel = firstLevel;
        }

        private void SetCurrentLevel()
        {
            Console.WriteLine(currentLevel); 
            initialNumberOfBacteria = ListOfLevels[currentLevel].GetInitialNumberOfBacteria();
            currentLevelDuration = ListOfLevels[currentLevel].GetInitialTime(); 
        }

        private void OnWin()
        {
            State = GameState.Win;
            EndingText.SetString(true);
            currentLevel++;
        }

        private void OnLose()
        {
            State = GameState.Lose;
            EndingText.SetString(false);
        }
    }
}
