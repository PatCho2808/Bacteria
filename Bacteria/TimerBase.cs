using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Bacteria
{
    class TimerBase : TextObject
    {

        protected Clock Clock = new Clock();

        public TimerBase(Font newFont, SFML.System.Vector2f WindowSize) : base(newFont, WindowSize)
        {
        }

        public void SetNewTimer()
        {
            Clock.Restart();
        }

        public virtual float GetRemainingTime()
        {
            return 0; 
        }

        public virtual void Update() { }
    }
}
