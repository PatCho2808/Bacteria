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
        //protected string TexturePath;
        protected Texture Texture { get; set; }
        protected Sprite Sprite { get; set; } 

        public Object(string path)
        {
            Texture = new Texture(path);
            Sprite = new Sprite(Texture); 
        }

        public void Draw(RenderTarget target,RenderStates states)
        {
            target.Draw(Sprite); 
        }

    }
}
