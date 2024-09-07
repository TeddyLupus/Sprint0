using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


// Everything works, but I'm sure it's not at all best practice.
// However, I'm going home on Friday and don't want to work at home.
namespace Tester3
{
    internal class MouseCont : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private MouseState oldState;
        Game1 myGame;
        // constructor
        public MouseCont(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand >();
            myGame = game;
            
            // set up teh table
            ICommand c = new CommQuit(game);
            RegisterCommand(Keys.D0, c);

            ICommand c1 = new Comm1(game);
            RegisterCommand(Keys.D1, c1);

            ICommand c2 = new Comm2(game);
            RegisterCommand(Keys.D2, c2);
            
            ICommand c3 = new Comm3(game);
            RegisterCommand(Keys.D3, c3);  

            ICommand c4 = new Comm4(game);  
            RegisterCommand(Keys.D4, c4);
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            MouseState newState = Mouse.GetState();
            

            // if there's a new click
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                //command
                Keys k = Where(newState);
                controllerMappings[k].Execute();
            }
            if (newState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released)
            {
                //command
                controllerMappings[Keys.D0].Execute();
            }
            oldState = newState;
        }

        private Keys Where(MouseState m)
        {
            Keys ans;

            int x = m.X;
            int y = m.Y;

            if (x > 400) // right half
            {
                if (y> 200)
                {
                    // right bottom
                    ans = Keys.D4;
                }
                else
                {
                    // right top
                    ans = Keys.D2;
                }
            }
            else // left half
            {
                if (y > 200)
                {
                    // left bottom
                    ans = Keys.D3;
                }
                else
                {
                    //left top
                    ans = Keys.D1;
                }
            }
            return ans;
        }
    }
}
