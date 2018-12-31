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

        public override void Update()
        {
            Text.DisplayedString = "Time to spawn next bacteria: " + String.Format("{0:0.0}", GetRemainingTime());
            Text.Scale = new Vector2f(0.5f, 0.5f);
        }


    }
}
