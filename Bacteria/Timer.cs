using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Bacteria
{
    

    class Timer : Drawable
    {
        private Font Font;
        private Text Text = new Text();
        private int levelDuration = 20;
        private Clock Clock = new Clock();
        private float windowWidth; 
     
        public Timer(Font newFont, SFML.System.Vector2f WindowSize)
        {
            Font = newFont;
            Text.Font = Font;
            windowWidth = WindowSize.X;
            Text.Scale = new Vector2f(1.5f, 1.5f);
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

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Text); 
        }

        public float GetRemainingTime()
        {
            return 10 - Clock.ElapsedTime.AsSeconds(); 
        }

    }
}
