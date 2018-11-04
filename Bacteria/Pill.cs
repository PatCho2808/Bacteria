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

        public Pill(string path) : base(path)
        {
            posX = 400;
            posY = 300;
            Sprite.Position = new SFML.System.Vector2f(posX, posY);

            SizeX = 2;
            SizeY = 2;
            Sprite.Scale = new SFML.System.Vector2f(SizeX, SizeY);

            rotation = 90;
            Sprite.Rotation = rotation;
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
