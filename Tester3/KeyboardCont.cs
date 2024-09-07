using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tester3
{
    internal class KeyboardCont : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        Game1 myGame;
        // constructor
        public KeyboardCont(Game1 game)
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
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                //myGame.Exit();
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                }
            }
        }
    }
}
