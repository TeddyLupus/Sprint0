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
    internal class FixedSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 position;
        
        public FixedSprite(Texture2D texture) 
        {
            Texture = texture;
        }
        public void Update(GameTime g) { 
            // No need becuase not moving?
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location) {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, location, null, Color.White);
            spriteBatch.End();
        }
    }
}
