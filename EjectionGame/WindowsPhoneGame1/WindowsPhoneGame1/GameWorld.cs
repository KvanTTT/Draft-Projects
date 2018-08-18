#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Devices;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;
using System.Xml;
using Box2D.XNA;
using Utilities;
using System.Xml.Linq;

#endregion

namespace EjectionGame
{
    public class GameWorld : GameScreen
    {
        #region Fields

        public Game game;

        public ContentManager content;
        public SpriteFont gameFont;

        public World physWorld;
        public SpriteBatch spriteBatch;

        public Texture2D background;   

        Camera camera;
        Dictionary<string, DrawableGameComponent> units;

        public float width;
        public float height;
        const float borderWidth = 0.05f;

        Random random = new Random();

        #endregion


        #region Initialization

        public GameWorld()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            EnabledGestures = GestureType.FreeDrag |
                GestureType.DragComplete |
                GestureType.Tap;
        }

        public override void LoadContent()
        {
            DebugDraw = true;

            primitiveBatch = new PrimitiveBatch(ScreenManager.GraphicsDevice);

            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            gameFont = content.Load<SpriteFont>("Fonts/gamefont");
            background = content.Load<Texture2D>("Textures/background");

            Vector2 gravity = new Vector2(0, 0.0f);
            physWorld = new World(gravity, true);	

            units = new Dictionary<string, DrawableGameComponent>(4);

            LoadLevel();    

            CreateBorders();            

            units.Add("Player", new Chip(this, new Vector2(0.5f, 0.4f), 0.07f,
                1.0f, 0.6f, 0.5f, content.Load<Texture2D>("Textures/Circle"), content.Load<SoundEffect>("Sounds/Hit")));

            units.Add("Player2", new Chip(this, new Vector2(0.6f, 0.7f), 0.07f,
                1.0f, 0.6f, 0.5f, content.Load<Texture2D>("Textures/Ball"), content.Load<SoundEffect>("Sounds/Hit")));

            camera = new Camera(this, new Rectangle(0, 0, 480, 800), (units["Player"] as Chip), new Vector2(1.0f, 1.0f));

            // A real game would probably have more content than this sample, so
            // it would take longer to load. We simulate that by delaying for a
            // while, giving you a chance to admire the beautiful loading screen.
            Thread.Sleep(1000);

            // once the load has finished, we use ResetElapsedTime to tell the game's
            // timing mechanism that we have just finished a very long frame, and that
            // it should not try to catch up.
            ScreenManager.Game.ResetElapsedTime();  
        }

        public void LoadLevel()
        {          
            List<FloatShape> Bodies = new List<FloatShape>();
            XDocument Doc = XDocument.Load(@"Content\Levels\Level1.xml");
            XElement SizeElem = Doc.Root.Element("FloatSize");
            FloatSize WorldSize = Loader.DeserializeObject(SizeElem.ToString(), typeof(FloatSize)) as FloatSize;
            width = WorldSize.X;
            height = WorldSize.Y;

            foreach (XElement Elem in Doc.Root.Elements())
            {
                if (Elem.Name == "FloatRect")
                    Bodies.Add(Loader.DeserializeObject(Elem.ToString(), typeof(FloatRect)) as FloatRect);
                else
                    if (Elem.Name == "FloatCircle")
                        Bodies.Add(Loader.DeserializeObject(Elem.ToString(), typeof(FloatCircle)) as FloatCircle);
                    else
                        if (Elem.Name == "FloatPolygon")
                            Bodies.Add(Loader.DeserializeObject(Elem.ToString(), typeof(FloatPolygon)) as FloatPolygon);
                        else
                            if (Elem.Name == "FloatLine")
                                Bodies.Add(Loader.DeserializeObject(Elem.ToString(), typeof(FloatLine)) as FloatLine);
            }

            foreach (FloatRect Rect in Bodies)
            {
                    units.Add(Rect.Name, new Wall(this,
                        new Vector2(Rect.Left + Rect.Width / 2,
                                    Rect.Top + Rect.Height / 2),
                                    new Vector2(Rect.Width, Rect.Height),
                                    content.Load<Texture2D>("Textures/Box"), null, camera));
            }
        }

        public void CreateBorders()
        {
            units.Add("LeftBorder", new Wall(this,
                new Vector2(-borderWidth / 2, height / 2), new Vector2(borderWidth, height), null, null, camera));

            units.Add("RightBorder", new Wall(this,
                new Vector2(width + borderWidth / 2, height / 2), new Vector2(borderWidth, height), null, null, camera));

            units.Add("TopBorder", new Wall(this,
                new Vector2(width / 2, -borderWidth / 2), new Vector2(width, borderWidth), null, null, camera));

            units.Add("BottomBorder", new Wall(this,
                new Vector2(width / 2, height + borderWidth / 2), new Vector2(width, borderWidth), null, null, camera));
        }

        public override void UnloadContent()
        {
            content.Unload();
        }

        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the state of the game. This method checks the GameScreen.IsActive
        /// property, so the game will stop updating when the pause menu is active,
        /// or if you tab away to a different application.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            if (IsActive)
            {
                physWorld.Step((float)gameTime.ElapsedGameTime.TotalSeconds, 6, 2);
                physWorld.ClearForces();


                /*
                // Apply some random jitter to make the enemy move around.
                const float randomization = 10;

                enemyPosition.X += (float)(random.NextDouble() - 0.5) * randomization;
                enemyPosition.Y += (float)(random.NextDouble() - 0.5) * randomization;

                // Apply a stabilizing force to stop the enemy moving off the screen.
                Vector2 targetPosition = new Vector2(
                    ScreenManager.GraphicsDevice.Viewport.Width / 2 - gameFont.MeasureString("Insert Gameplay Here").X / 2, 
                    200);

                enemyPosition = Vector2.Lerp(enemyPosition, targetPosition, 0.05f);

                // TODO: this game isn't very fun! You could probably improve
                // it by inserting something more interesting in this space :-)*/
            }
        }


        /// <summary>
        /// Lets the game respond to player input. Unlike the Update method,
        /// this will only be called when the gameplay screen is active.
        /// </summary>
        public override void HandleInput(InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            // Look up inputs for the active player profile.
            int playerIndex = (int)ControllingPlayer.Value;

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];

            // if the user pressed the back button, we return to the main menu
            PlayerIndex player;
            if (input.IsNewButtonPress(Buttons.Back, ControllingPlayer, out player))
            {
                LoadingScreen.Load(ScreenManager, false, ControllingPlayer, new BackgroundScreen(), new MainMenuScreen());
            }
            else
            {
                // Otherwise move the player position.
                Vector2 movement = Vector2.Zero;

                if (keyboardState.IsKeyDown(Keys.Left))
                    movement.X--;

                if (keyboardState.IsKeyDown(Keys.Right))
                    movement.X++;

                if (keyboardState.IsKeyDown(Keys.Up))
                    movement.Y--;

                if (keyboardState.IsKeyDown(Keys.Down))
                    movement.Y++;

                Vector2 thumbstick = gamePadState.ThumbSticks.Left;

                movement.X += thumbstick.X;
                movement.Y -= thumbstick.Y;

                if (movement.Length() > 1)
                    movement.Normalize();
            }

            // Read all available gestures
            foreach (GestureSample gestureSample in input.Gestures)
            {
                (units["Player"] as Chip).HandleInput(gestureSample);
            }
        }


        /// <summary>
        /// Draws the gameplay screen.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target,
                                               Color.CornflowerBlue, 0, 0);

            if (DebugDraw)
            {
                /*primitiveBatch.Begin(PrimitiveType.LineList);
                primitiveBatch.AddVertex(new Vector2(220, 400), Color.Red);
                primitiveBatch.AddVertex(new Vector2(260, 400), Color.White);
                primitiveBatch.AddVertex(new Vector2(240, 360), Color.White);
                primitiveBatch.AddVertex(new Vector2(240, 420), Color.White);
                primitiveBatch.End();*/

                Draw(gameTime, camera);
            }
            else
            {
                ScreenManager.SpriteBatch.Begin();

                Draw(gameTime, camera);

                ScreenManager.SpriteBatch.End();
            }            

            // If the game is transitioning on or off, fade it out to black.
            if (TransitionPosition > 0)
                ScreenManager.FadeBackBufferToBlack(1f - TransitionAlpha);
            
            
        }

        public void Draw(GameTime gameTime, Camera cam)
        {
            cam.Update(gameTime);

            //ScreenManager.SpriteBatch.Draw(background, cam.DestRect, cam.BackgroundRect, Color.White);
            (units["Player"] as Chip).Draw(gameTime, cam);
            (units["Player2"] as Chip).Draw(gameTime, cam);

            foreach (KeyValuePair<string, DrawableGameComponent> Obj in units)
            {
                if (Obj.Value is Wall)
                {                    
                    (Obj.Value as Wall).Draw(gameTime, cam);
                }
            }
        }


        #endregion
    }
}
