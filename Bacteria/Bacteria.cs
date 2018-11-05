using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacteria
{
    class Bacteria : Object 
    {
        public Bacteria(string path) : base (path)
        {
            Sprite.Position = new SFML.System.Vector2f(50, 50);
            //Sprite.Scale = new SFML.System.Vector2f(2, 2);
        }
    }
}
