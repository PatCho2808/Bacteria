using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacteria 
{
    class Pill : Object
    {
        public Pill(string path) : base(path)
        {
            posX = 400;
            posY = 300;
            Sprite.Position = new SFML.System.Vector2f(posX, posY);

            SizeX = 3;
            SizeY = 3;
            Sprite.Scale = new SFML.System.Vector2f(SizeX, SizeY);

            rotation = 90;
            Sprite.Rotation = rotation;
        }
    }
}
