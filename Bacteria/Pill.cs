using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;

namespace Bacteria 
{
    class Pill : Object
    {

        private float speed;
        private float initialSpeed = 0.1f;
        private SFML.System.Vector2f WindowSize; 

        public Pill(string path, SFML.System.Vector2f WindowSize) : base(path)
        {
            Sprite.Position = new SFML.System.Vector2f(WindowSize.X/2, WindowSize.Y/2);
            Sprite.Rotation = 90;
            speed = initialSpeed;

            this.WindowSize = WindowSize; 
        }

        private void MoveRight()
        {
            if(Sprite.Position.X < WindowSize.X - Sprite.GetGlobalBounds().Width/2)
                Sprite.Position = new SFML.System.Vector2f(Sprite.Position.X + speed, Sprite.Position.Y);
        }

        private void MoveLeft()
        {
            if (Sprite.Position.X > Sprite.GetGlobalBounds().Width / 2)
                Sprite.Position = new SFML.System.Vector2f(Sprite.Position.X - speed, Sprite.Position.Y);

        }

        private void MoveUp()
        {
            if (Sprite.Position.Y > Sprite.GetGlobalBounds().Height / 2)
                Sprite.Position = new SFML.System.Vector2f(Sprite.Position.X, Sprite.Position.Y - speed);
        }

        private void MoveDown()
        {
            if (Sprite.Position.Y < WindowSize.Y - Sprite.GetGlobalBounds().Height / 2)
                Sprite.Position = new SFML.System.Vector2f(Sprite.Position.X, Sprite.Position.Y + speed);
        }

        public void Update()
        {
            Move(); 
        }

        private void Move()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                MoveUp();
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                MoveDown();
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                MoveRight();
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                MoveLeft();
            }
        }

        public void AddSpeed(float x)
        {
            speed += x;
        }

        public void ResetSpeed()
        {
            speed = initialSpeed;
        }

    }
}
