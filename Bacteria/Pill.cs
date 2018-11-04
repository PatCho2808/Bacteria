using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacteria 
{
    class Pill : Object
    {

        private float speed = 0.1f;
        private SFML.System.Vector2f WindowSize; 

        public Pill(string path, SFML.System.Vector2f WindowSize ) : base(path)
        {
            Sprite.Position = new SFML.System.Vector2f(WindowSize.X/2, WindowSize.Y/2);
            Sprite.Scale = new SFML.System.Vector2f(2, 2);
            Sprite.Rotation = 90;

            this.WindowSize = WindowSize; 
        }

        public void MoveRight()
        {
            if(Sprite.Position.X < WindowSize.X - Sprite.GetGlobalBounds().Width/2)
                Sprite.Position = new SFML.System.Vector2f(Sprite.Position.X + speed, Sprite.Position.Y);
        }

        public void MoveLeft()
        {
            if (Sprite.Position.X > Sprite.GetGlobalBounds().Width / 2)
                Sprite.Position = new SFML.System.Vector2f(Sprite.Position.X - speed, Sprite.Position.Y);

        }

        public void MoveUp()
        {
            if (Sprite.Position.Y > Sprite.GetGlobalBounds().Height / 2)
                Sprite.Position = new SFML.System.Vector2f(Sprite.Position.X, Sprite.Position.Y - speed);
        }

        public void MoveDown()
        {
            if (Sprite.Position.Y < WindowSize.Y - Sprite.GetGlobalBounds().Height / 2)
                Sprite.Position = new SFML.System.Vector2f(Sprite.Position.X, Sprite.Position.Y + speed);
        }

    }
}
