using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Data.Common;

namespace Tester3
{
    internal class TextSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 position;

        
        public TextSprite(Texture2D texture) 
        {
            // this doesn't do anything?
        }
        public void Update(GameTime g) { 
            // No need becuase not moving?
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location) {
            spriteBatch.Begin();
            //spriteBatch.DrawString( font, "Credits\n Program Made By: Vivian Qian\n Sprites from: \nwww.spriters-resource.com/snes/kirbysuperstarkirbysfunpak/sheet/2898/\n Also www.dafont.com/lemon-milk.font", location, Color.Black);
            spriteBatch.End();
        }
    }
}
