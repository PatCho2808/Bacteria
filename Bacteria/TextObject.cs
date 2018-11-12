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
        protected float windowWidth;
        protected float windowHeight;

        public TextObject(Font newFont, SFML.System.Vector2f WindowSize)
        {
            Font = newFont;
            Text.Font = Font;
            windowHeight = WindowSize.Y;
            windowWidth = WindowSize.X;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Text);
        }
    }
}
