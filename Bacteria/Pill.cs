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
            posX = 475;
            posY = 200;

            SizeX = 3;
            SizeY = 3;

            rotation = 90;

            SetSpriteRotation();
            SetSpritePosition();
            SetSpriteSize();
            
        }
    }
}
