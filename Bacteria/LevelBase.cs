using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;


namespace Bacteria
{
    abstract class LevelBase : Drawable
    {
        protected struct Data
        {
            public int initialNumberOfBacteria;
            public int initialTime; 
        }

        protected Data LevelData;

        abstract public void Update();
        abstract public void SetLevel();
        abstract public void Draw(RenderTarget target, RenderStates states);

        public int GetInitialNumberOfBacteria()
        {
            return LevelData.initialNumberOfBacteria; 
        }

        public int GetInitialTime()
        {
            return LevelData.initialTime;
        }



        
    }
}
