using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacteria
{
    class Bacteria : Object 
    {
        static Random Rand = new Random(); 

        public Bacteria(string path, int maxX, int maxY) : base (path)
        {
            CreateBacteriaOnRandomPosition(maxX, maxY);
        }

        private void CreateBacteriaOnRandomPosition(int maxX, int maxY)
        {
            int x = Rand.Next((int)(Sprite.GetGlobalBounds().Width/2), (int)(maxX - Sprite.GetGlobalBounds().Width/2));
            int y = Rand.Next((int)(Sprite.GetGlobalBounds().Height/2),(int)(maxY - Sprite.GetGlobalBounds().Height / 2));
            Sprite.Position = new SFML.System.Vector2f(x, y);
        }

    }
}
