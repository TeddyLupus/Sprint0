using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Tester3
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private IController controllerK;
        private IController controllerM;
        public ISprite kirbyStanding;
        public ISprite kirbyStandingM;
        public ISprite kirbyMoving;
        public ISprite kirbyMovingM;
        public ISprite kirbySprite;

        private SpriteFont font;
        public ISprite textSprite;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            controllerK = new KeyboardCont(this);
            controllerM = new MouseCont(this);

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Lemon");
            textSprite = new TextSprite(null);
            // unsure if allowed
            Texture2D standing = Content.Load<Texture2D>("standingKirby");
            kirbySprite = new FixedSprite(standing);
            // option is to load all sprites and keep track of which one is the current sprite
            // option is to have a data object and you construct with the data object?
            
            // It's not sustainable (probably) but I just photoshopped the frames into atlas form.
            Texture2D moving = Content.Load<Texture2D>("KirbyAtlas");
            
            //For time's sake we're just making the objects here.
            kirbyMoving = new AnimatedSpriteS(moving, 1, 9);
            kirbyMovingM = new AnimatedSpriteM(moving, 1, 9);
            kirbyStandingM = new FixedSpriteM(standing);
            kirbyStanding = new FixedSprite(standing);


            // TODO: use this.Content to load your game content here

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           
            // TODO: Add your update logic here
            controllerK.Update();
            controllerM.Update();
            kirbySprite.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            kirbySprite.Draw(spriteBatch, new Vector2(400, 200));

            // yeah i don't understand how to use the sprite interface i have for text
            // it seems like the parameters would be different...
            //textSprite.Draw(spriteBatch, new Vector2(10, 300));
            spriteBatch.Begin();

            spriteBatch.DrawString(font, "Credits\n Program Made By: Vivian Qian\n Sprites from: \nwww.spriters-resource.com/snes/kirbysuperstarkirbysfunpak/sheet/2898/\n Also www.dafont.com/lemon-milk.font", new Vector2(10, 300), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
