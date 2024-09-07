using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Tester3
{
    // might just open this 
    public interface ISprite
    {
        public void Update(GameTime g);

        public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
