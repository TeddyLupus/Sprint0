using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Data.Common;
using System.ComponentModel.Design;

namespace Tester3
{
    internal class FixedSpriteM : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 position;
        private int flag;
        
        public FixedSpriteM(Texture2D texture) 
        {
            Texture = texture;
            //Also wrong but fix later?
            position = new Vector2(400, 200);
            flag = 0;
        }
        public void Update(GameTime g)
        {
            // Move down and then loop around there's definitely a better way to do this.
            if (position.Y < 430 && flag ==0) { 
                position.Y++;
            }
            if (position.Y > 0 && flag == 1)
            {
                position.Y--;
            }
            if (position.Y == 0)
            {
                flag = 0;
            }
            if (position.Y == 430)
            {
                flag = 1;
            }
           
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location) {
            // we dont even use location here haha...fix later
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, position, null, Color.White);
            spriteBatch.End();
        }
    }
}
