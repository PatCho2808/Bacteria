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
        protected float SizeX, SizeY;
        protected float posX, posY;
        protected float rotation; 

        public Object(string path)
        {
            Texture = new Texture(path);
            Sprite = new Sprite(Texture); 
        }

        public void Draw(RenderTarget target,RenderStates states)
        {
            target.Draw(Sprite); 
        }

        public void SetSpriteSize()
        {
            Sprite.Scale = new SFML.System.Vector2f(SizeX, SizeY); 
        }

        public void SetSpritePosition()
        {
            float newPosX = posX - Sprite.GetGlobalBounds().Width;
            float newPosY = posY - Sprite.GetGlobalBounds().Height;

            Sprite.Position = new SFML.System.Vector2f(newPosX, newPosY); 
        }

        public void SetSpriteRotation()
        {
            Sprite.Rotation = rotation;
        }

    }
}
