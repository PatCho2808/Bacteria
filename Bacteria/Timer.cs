using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Bacteria
{
    

    class Timer : TextObject
    {
        public int levelDuration;
        private Clock Clock = new Clock();
     
        public Timer(Font newFont, SFML.System.Vector2f WindowSize, int newLevelDuration) :base(newFont, WindowSize)
        {
            
            Text.Scale = new Vector2f(1.5f, 1.5f);
            levelDuration = newLevelDuration;
            SetNewTimer(); 
        }

        public void SetNewTimer()
        {
            Clock.Restart(); 
        }

        public void Update()
        {
            if(Text.DisplayedString != "0")
            {
                Text.DisplayedString = (levelDuration - (int)Clock.ElapsedTime.AsSeconds()).ToString();
                Text.Position = new Vector2f(windowWidth - Text.GetGlobalBounds().Width * 2, Text.GetGlobalBounds().Height);
            }            
        }

        public float GetRemainingTime()
        {
            return levelDuration - Clock.ElapsedTime.AsSeconds(); 
        }

    }
}
