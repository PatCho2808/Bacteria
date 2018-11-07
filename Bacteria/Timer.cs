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
        private int levelDuration = 10;
        private Clock Clock = new Clock(); 
     
        public Timer(Font newFont)
        {
            Font = newFont;
            Text.Font = Font;
            Text.Position = new Vector2f(100, 100);
            SetNewTimer(); 
        }

        public void SetNewTimer()
        {
            Clock.Restart(); 
        }

        public void Update()
        {
            if(Text.DisplayedString != "0")
                Text.DisplayedString = (levelDuration - (int)Clock.ElapsedTime.AsSeconds()).ToString(); 
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Text); 
        }

    }
}
