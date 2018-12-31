using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;


namespace Bacteria
{
    class ThirdLevel : LevelBase
    {
        public ThirdLevel()
        {
            LevelData.initialNumberOfBacteria = 25;
            LevelData.initialTime = 7;
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