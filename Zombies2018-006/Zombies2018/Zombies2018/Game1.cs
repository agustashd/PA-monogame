using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using Zombies2018.Sprites;

namespace Zombies2018
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public enum Fuentes
        {
            Estadisticas, BigFont
        }

        public enum Sonidos
        {
            Explosion, Disparo
        }

        #region variables

        Song miCancion;


        public Dictionary<Sonidos, SoundEffect> Sounds { get; private set; }

        /// <summary>
        /// Almaceno todas las fuentes en un Dictionary
        /// </summary>
        public Dictionary<Fuentes, SpriteFont> Fonts { get; private set; }


        /// <summary>
        /// Singleton. Unica instancia de Game1 que quiero
        /// </summary>
        internal static Game1 TheGame { get; private set; }

        /// <summary>
        /// Permite acceder o setear caracteristicas
        /// de la pantalla de juego
        /// </summary>
        internal GraphicsDeviceManager graphics { get; private set; }
        
        /// <summary>
        /// Me permite dibujar imagenes en pantalla
        /// </summary>
        internal SpriteBatch spriteBatch { get; private set; }

        internal List<Updateable> sprites { get; private set; }
        internal List<Sprite> Actualizaciones { get; private set; }

        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            Fonts = new Dictionary<Fuentes, SpriteFont>();
            Sounds = new Dictionary<Sonidos, SoundEffect>();

            // TODO: use this.Content to load your game content here
            Actualizaciones = new List<Sprite>();
            sprites = new List<Updateable>();

            miCancion = Content.Load<Song>("SongEffects/Zombiee");

            Sounds.Add(Sonidos.Explosion, 
                        Content.Load<SoundEffect>("SongEffects/Explosion2"));
            Sounds.Add(Sonidos.Disparo,
                         Content.Load<SoundEffect>("SongEffects/bullet"));

            Fonts.Add(Fuentes.BigFont, 
                        Content.Load<SpriteFont>("Fonts/BigFont"));
            Fonts.Add(Fuentes.Estadisticas, 
                        Content.Load<SpriteFont>("Fonts/Stats"));

            sprites.Add(new BackGround());
            sprites.Add(new ZombieFactory());
            sprites.Add(new Xena());
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
                MediaPlayer.Play(miCancion);
                firstRun = false;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (var item in sprites)
            {
                item.Update(gameTime);
            }

            foreach (var item in Actualizaciones)
            {
                if (sprites.Contains(item))
                    sprites.Remove(item);
                else
                    sprites.Add(item);
            }

            //sprites.AddRange(Actualizaciones);
            Actualizaciones.Clear();

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
            spriteBatch.Begin();
            foreach (var item in sprites)
            {
                if (item is Sprite)
                    ((Sprite)item).Draw(gameTime);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
