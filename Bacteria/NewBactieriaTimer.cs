using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Bacteria
{
    class NewBactieriaTimer : TimerBase
    {
        float timeBetweenNewBacteria; 

        public NewBactieriaTimer(Font newFont, SFML.System.Vector2f WindowSize, int timeBetweenNewBacteria) : base(newFont, WindowSize)
        {
            this.timeBetweenNewBacteria = timeBetweenNewBacteria;
            SetNewTimer();
        }

        public override float GetRemainingTime()
        {
            return timeBetweenNewBacteria - Clock.ElapsedTime.AsSeconds(); 
        }
    }
}
