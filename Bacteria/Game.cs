using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace Bacteria
{
    class Game
    {
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        public Game(uint x, uint y)
        {
            RenderWindow window = new RenderWindow(new VideoMode(x, y), "Bacteria", SFML.Window.Styles.Close);
            window.Closed += new EventHandler(OnClose);
            GameLoop(window);
        }

        public void GameLoop(RenderWindow window)
        {
            while(window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(new Color(34, 37, 47));
                window.Display(); 
            }
        }

        
    }
}
