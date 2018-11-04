using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Bacteria
{
    class Object : Drawable 
    {
        protected Texture Texture { get; set; }
        protected Sprite Sprite { get; set; }

        public Object(string path)
        {
            Texture = new Texture(path);
            Sprite = new Sprite(Texture);
            Sprite.Origin = new SFML.System.Vector2f(Sprite.GetGlobalBounds().Width / 2, Sprite.GetGlobalBounds().Height / 2);
        }

        public void Draw(RenderTarget target,RenderStates states)
        {
            target.Draw(Sprite); 
        }

    }
}
