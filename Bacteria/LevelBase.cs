using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacteria
{
    abstract class LevelBase
    {
        protected struct Data
        {
            public int initialNumberOfBacteria;
            public int initialTime; 
        }

        protected Data LevelData;

        abstract public void Update();

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
