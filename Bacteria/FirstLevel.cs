using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Bacteria
{
    class FirstLevel : LevelBase
    {
        public FirstLevel()
        {
            LevelData.initialNumberOfBacteria = 13;
            LevelData.initialTime = 10; 
        }

        public override void Update()
        {
        }

        public override void SetLevel()
        {

        }

        public override void Draw(RenderTarget target, RenderStates states)
        {

        }
    }
}
