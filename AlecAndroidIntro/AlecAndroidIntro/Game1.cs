using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlecAndroidIntro
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite ground;
        Dino dino;
        TouchCollection touches;
        SoundEffect footstep;
        Random r;
        List<Sprite> enemies = new List<Sprite>();
        SoundEffectInstance footstepInstance;
        SpriteFont font;
        TimeSpan generateTime = TimeSpan.FromMilliseconds(1500);
        TimeSpan elapsedGenerateTime = TimeSpan.Zero;
        int score;
        bool dead = false;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            //graphics.PreferredBackBufferWidth = 800;
            //graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        /// <summary>C:\Users\AlecGeoSimonian\Documents\GitHub\AndroidIntro\AlecAndroidIntro\AlecAndroidIntro\Assets\
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
            r = new Random();
            // Create a new SpriteBatch, which can be used to draw textures.

            //for(int i = 0; i < 20000; i++)
            //{
            //    Sprite sprite = new Sprite(Content.Load<Texture2D>("cactus"), new Vector2(r.Next(4000, 10000000), GraphicsDevice.Viewport.Height - 310), Color.White);
            //    foreach(Sprite enemy in enemies)
            //    {
            //        if(sprite.hitbox.Intersects(enemy.hitbox))
            //        {
            //            sprite.position.X = r.Next(4000, 10000000);
            //        }
            //    }
            //    enemies.Add(sprite);
            //}


            spriteBatch = new SpriteBatch(GraphicsDevice);
            ground = new Sprite(Content.Load<Texture2D>("ground"), new Vector2(0, GraphicsDevice.Viewport.Height - 50), Color.White);
            dino = new Dino(Content.Load<Texture2D>("dinosaur"), new Vector2(0, GraphicsDevice.Viewport.Height - 50 - 279), Color.White, 20, 100, 50);
            font = Content.Load<SpriteFont>("spriteFont");
        
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                Exit();
            }

            elapsedGenerateTime += gameTime.ElapsedGameTime;

            if (elapsedGenerateTime >= generateTime)
            {
                Sprite sprite = new Sprite(Content.Load<Texture2D>("cactus"), new Vector2(GraphicsDevice.Viewport.Width + 100, GraphicsDevice.Viewport.Height - 310), Color.White);
                enemies.Add(sprite);
                generateTime = TimeSpan.FromMilliseconds(r.Next(987, 2789));
                score++;
                elapsedGenerateTime = TimeSpan.Zero;

            }

            foreach (Sprite enemy in enemies)
            {
                enemy.Update(gameTime);
                enemy.position.X -= 10;
                if (dino.hitbox.Intersects(enemy.hitbox))
                {
                    // This is a loss. 
                    // Switch to lose mode
                    // 
                    dead = true;
                }
            }



            // TODO: Add your update logic here
            touches = TouchPanel.GetState();
            ground.Update(gameTime);
            dino.Update(touches, gameTime, GraphicsDevice.Viewport);
            if (dead == true)
            {

            }
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
            foreach (Sprite sprite in enemies)
            {
                sprite.Draw(spriteBatch);
                
            }
            spriteBatch.DrawString(font, $"Score: {score}", new Vector2(50, 50), Color.YellowGreen);
            ground.Draw(spriteBatch);            
         
                if (dead == true)
                {
                    spriteBatch.DrawString(font, "RESTART", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), Color.Red);
                while (dead == true)
                {


                    if (touches.Count > 0)
                    {
                        score = 0;
                        dead = false;
                        enemies.Clear();
                    }
                }
                }
            
            dino.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

