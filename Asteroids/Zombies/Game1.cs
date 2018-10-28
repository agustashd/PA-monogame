using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Asteroids.Sprites;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Asteroids
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public enum Soundfx
        {
            Explosion, Laser
        }

        public enum Font
        {
            HUD 
        }

        Song backgroundSong;

        internal static Game1 TheGame { get; private set; }
        internal GraphicsDeviceManager graphics { get; private set; }
        internal SpriteBatch spriteBatch { get; private set; }
        internal List<Updateable> sprites { get; private set; }
        internal List<Sprite> actualizaciones { get; private set; }
        public Dictionary<Soundfx, SoundEffect> Sounds { get; private set; }
        public Dictionary<Font, SpriteFont> Fonts { get; private set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 300;
            graphics.PreferredBackBufferHeight = 500;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            TheGame = this;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Fonts = new Dictionary<Font, SpriteFont>();
            Sounds = new Dictionary<Soundfx, SoundEffect>();

            // TODO: use this.Content to load your game content here

            actualizaciones = new List<Sprite>();
            sprites = new List<Updateable>();

            backgroundSong = Content.Load<Song>("Sounds/ObservingTheStar");

            Sounds.Add(Soundfx.Explosion, Content.Load<SoundEffect>("Sounds/explosion"));
            Sounds.Add(Soundfx.Laser, Content.Load<SoundEffect>("Sounds/laser9"));

            Fonts.Add(Font.HUD, Content.Load<SpriteFont>("Fonts/HUD"));

            sprites.Add(new AlienFactory());
            sprites.Add(new Background());
            sprites.Add(new Ship());
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        bool firstRun = true;
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (firstRun)
            {
                MediaPlayer.Play(backgroundSong);
                firstRun = false;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //xena.Update(gameTime);
            //asteroids.Update(gameTime);

            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime);
            }

            foreach (var sprite in actualizaciones)
            {
                if (sprites.Contains(sprite))
                {
                    sprites.Remove(sprite);
                }
                else
                {
                    sprites.Add(sprite);
                }
            }

            actualizaciones.Clear();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //asteroids.Draw(gameTime);
            //xena.Draw(gameTime);

            spriteBatch.Begin();
            foreach (var sprite in sprites)
            {
                if (sprite is Sprite)
                {
                    ((Sprite)sprite).Draw(gameTime);
                }
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
