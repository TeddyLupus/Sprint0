using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tester3
{
    internal class AnimatedSpriteM : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 position;
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        private int flag;
        private int temp;

        //Constructor
        public AnimatedSpriteM(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            temp = 0;

            //Also wrong but fix later?
            position = new Vector2(400, 200);
            flag = 0;
        }

        // Updates what frame we're on
        // I added game time as an arg, but idk how to make the animation slow down yet..
        public void Update(GameTime g)
        {
            // temp is my temporary solution to slow down the animation.
            temp++;
            if (temp > 4) {
                currentFrame++;
                temp = 0;
            }
            if (currentFrame == totalFrames)
                currentFrame = 0;

            int bound = 800 - (Texture.Width / Columns);
            // Move down and then loop around there's definitely a better way to do this.
            if (position.X < bound && flag == 0)
            {
                position.X++;
            }
            if (position.X > 0 && flag == 1)
            {
                position.X--;
            }
            if (position.X == 0)
            {
                flag = 0;
            }
            if (position.X == bound)
            {
                flag = 1;
            }
        }
        
        // determines which part of the atlas we draw and where and does the drawing
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            // THIS NEEDS TO BE FIXED BTW, right now though i just altered the image haha
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
