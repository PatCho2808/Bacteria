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

        public Pill(string path, SFML.System.Vector2f WindowSize ) : base(path)
        {
            Sprite.Position = new SFML.System.Vector2f(WindowSize.X, WindowSize.Y);
            Sprite.Scale = new SFML.System.Vector2f(2, 2);
            Sprite.Rotation = 90;
        }

        public void MoveRight()
        {
            Sprite.Position = new SFML.System.Vector2f(Sprite.Position.X + speed, Sprite.Position.Y); 
        }

        public void MoveLeft()
        {
            Sprite.Position = new SFML.System.Vector2f(Sprite.Position.X - speed, Sprite.Position.Y);
        }

        public void MoveUp()
        {
            Sprite.Position = new SFML.System.Vector2f(Sprite.Position.X, Sprite.Position.Y - speed);
        }

        public void MoveDown()
        {
            Sprite.Position = new SFML.System.Vector2f(Sprite.Position.X, Sprite.Position.Y + speed);
        }
    }
}
