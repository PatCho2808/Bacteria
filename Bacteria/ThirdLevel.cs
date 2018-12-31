using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;


namespace Bacteria
{
    class ThirdLevel : LevelBase
    {
        SecondLevel secondLevel;

        public ThirdLevel(Font newFont, SFML.System.Vector2f WindowSize)
        {
            LevelData.initialNumberOfBacteria = 25;
            LevelData.initialTime = 7;
            secondLevel = new SecondLevel(newFont, WindowSize); 
        }


        public override void Update()
        {
            secondLevel.Update();
        }

        public override void SetLevel()
        {
            secondLevel.SetLevel();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(secondLevel, states);
        }
    }
}