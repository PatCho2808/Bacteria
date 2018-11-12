using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Bacteria
{
    class TextObject : Drawable
    {
        protected Font Font;
        protected Text Text = new Text();

        public TextObject(Font newFont, SFML.System.Vector2f WindowSize)
        {
            Font = newFont;
            Text.Font = Font; 
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Text);
        }
    }
}
