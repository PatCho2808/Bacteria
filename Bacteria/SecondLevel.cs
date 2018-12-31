using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Bacteria
{
    class SecondLevel : LevelBase
    {
        NewBactieriaTimer newBacteriaTimer;
        Font font;
        SFML.System.Vector2f WindowSize;
        int timeBetweenNewBacteria;

        public SecondLevel(Font newFont, SFML.System.Vector2f WindowSize)
        {
            LevelData.initialNumberOfBacteria = 13;
            LevelData.initialTime = 10;
            timeBetweenNewBacteria = 3;
            this.font = newFont;
            this.WindowSize = WindowSize;
        }

        public override void Update()
        {
            newBacteriaTimer.Update();

            if(newBacteriaTimer.GetRemainingTime() <= 0)
            {
                Game.CreateNewBacteria();
                newBacteriaTimer.SetNewTimer();
            }
        }

        public override void SetLevel()
        {
            newBacteriaTimer = new NewBactieriaTimer(font, WindowSize, timeBetweenNewBacteria);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(newBacteriaTimer, states);
        }
    }
}
