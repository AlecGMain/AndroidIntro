using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;

namespace AlecAndroidIntro
{
    class Dino : Sprite
    {
        float initialspeed;
        float speed;
        float gravity = .5f;
        bool isJumping = false;

        int height;
        int fall;
        //keeps track of how much time has passed in our game
        TimeSpan elapsedTime;
        //how long we want to wait to do something
        TimeSpan timeToJump;

        public Dino(Texture2D Image, Vector2 Position, Color Color, float Speed, int Height, int Fall) : base(Image, Position, Color)
        {
            initialspeed = Speed;
            height = Height;
            fall = Fall;
            //TouchPanel.GetState();
            elapsedTime = TimeSpan.Zero;
            timeToJump = new TimeSpan(0, 0, 0, 0, 1);
        }

        public void Update(TouchCollection touches, GameTime gameTime, Viewport vp)
        {
            //adds how much time has passed to our elapsedTime
            elapsedTime += gameTime.ElapsedGameTime;

            if (touches.Count > 0)
            {
                if (touches[0].State == TouchLocationState.Pressed && !isJumping)
                {
                    isJumping = true;
                    speed = initialspeed;
                }                
            }

            if (isJumping)
            {
                speed -= gravity;
                position.Y -= speed;

                if (position.Y > 750)
                {
                    isJumping = false;
                    position.Y = 750;
                }
            }

            base.Update(gameTime);
        }








    }
}
