﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester3
{
    internal class Comm3 : ICommand
    {
        Game1 myGame;
        public Comm3(Game1 game) 
        {
            myGame = game;
        }
        public void Execute()
        {
            // Need help with this one!!!!
            myGame.kirbySprite = myGame.kirbyStandingM;
        }
    }
}
