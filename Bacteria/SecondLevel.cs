using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacteria
{
    class SecondLevel : LevelBase
    {
        public SecondLevel()
        {
            LevelData.initialNumberOfBacteria = 17;
            LevelData.initialTime = 10; 
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
