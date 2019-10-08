using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using Managers.ContentManager;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private static Game1 instance;

        public static Game1 Instance {
            get {
                if (instance == null) {
                    instance = new Game1();/*creating new instance of the game*/
                }
                return instance;/*if already created ..*/

            }
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private GameScreenManager gamescreenManager;
        public GameScreenManager GameScreenManager {
            get {
                return gamescreenManager;
            }
        }

        private InputManager inputManager;
        /*anyone can acces to InputManager thrue this Game class
         but u can only read it */
        public InputManager InputManager {
            get {
                return inputManager;
            }
        }
        public ContentManager  ContentManager { get; }

        public Game1() {/*construct*/ 

            graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
            IsMouseVisible = true;
            inputManager = new InputManager();
            gamescreenManager = new GameScreenManager();
            ContentManager = new ContentManager();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            
            gamescreenManager.Push(new StartupGamescreen());
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            ContentManager.Prepare(GraphicsDevice);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
             
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
      
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            inputManager.Update();
          
            gamescreenManager.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            gamescreenManager.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
