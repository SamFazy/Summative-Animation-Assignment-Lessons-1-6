using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Summative_Animation_Assignment_Lessons_1_6
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        MouseState mouseState;

        Texture2D applePearIntroTexture;

        Texture2D raceTrackTexture;
        Rectangle raceTrackRect;
        Vector2 raceTrackSpeed;
        Texture2D raceTrackTextureDouble;
        Rectangle raceTrackRectDouble;
        Vector2 raceTrackSpeedDouble;

        Texture2D appleTexture;
        Rectangle appleRect;
        Vector2 appleSpeed;

        Texture2D pearTexture;
        Rectangle pearRect;
        Vector2 pearSpeed;

        Texture2D appleWinScreenTexture;
        Rectangle appleWinScreenRect;


        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            screen = Screen.Intro;

        }

        enum Screen
        {
            Intro,
            ApplePearRaceBackground
        }

        Screen screen;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            raceTrackRect = new Rectangle(0, 0, 800, 500);
            raceTrackSpeed = new Vector2(-50, 0);

            raceTrackRectDouble = new Rectangle(800, 0, 800, 500);
            raceTrackSpeedDouble = new Vector2(-50, 0);

            appleRect = new Rectangle(-400, 300, 100, 100);
            appleSpeed = new Vector2(3, 0);

            pearRect = new Rectangle(-110, 390, 100, 100);
            pearSpeed = new Vector2(2, 0);

            appleWinScreenRect = new Rectangle(-1000, -1000, 800, 500);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            applePearIntroTexture = Content.Load<Texture2D>("ApplePearRaceBackground");

            appleWinScreenTexture = Content.Load<Texture2D>("appleWinScreen");

            raceTrackTexture = Content.Load<Texture2D>("RaceTrackBackground");
            raceTrackTextureDouble = Content.Load<Texture2D>("RaceTrackBackground");

            appleTexture = Content.Load<Texture2D>("apple");
            pearTexture = Content.Load<Texture2D>("pear");
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.ApplePearRaceBackground;
            }
            else if (screen == Screen.ApplePearRaceBackground)
            {
                raceTrackRect.X += (int)raceTrackSpeed.X;
                raceTrackRectDouble.X += (int)raceTrackSpeedDouble.X;
                if (raceTrackRect.Right == 800)
                {
                    raceTrackRectDouble = new Rectangle(800, 0, 800, 500);
                }
                if (raceTrackRectDouble.Right == 800)
                {
                    raceTrackRect = new Rectangle(800, 0, 800, 500);
                }

                appleRect.X += (int)appleSpeed.X;
                pearRect.X += (int)pearSpeed.X;

                if (pearRect.X == 804)
                {
                    appleWinScreenRect = new Rectangle(0, 0, 800, 500);
                }

            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(applePearIntroTexture, new Rectangle(0, 0, 800, 500), Color.White);
            }
            else if (screen == Screen.ApplePearRaceBackground)
            {
                _spriteBatch.Draw(raceTrackTexture, raceTrackRect, Color.White);
                _spriteBatch.Draw(raceTrackTextureDouble, raceTrackRectDouble, Color.White);

                _spriteBatch.Draw(appleTexture, appleRect, Color.White);
                _spriteBatch.Draw(pearTexture, pearRect, Color.White);

                _spriteBatch.Draw(appleWinScreenTexture, appleWinScreenRect, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
