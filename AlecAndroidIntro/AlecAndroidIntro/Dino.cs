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

namespace AlecAndroidIntro
{
    class Dino : Sprite
    {
        int speed;
        int height;
        int fall;
        public Dino(Texture2D Image, Vector2 Position, Color Color,int Speed, int Height, int Fall) : base(Image, Position, Color)
        {
            speed = Speed;
            height = Height;
            fall = Fall;
            //TouchPanel.GetState();
        }

        public void Update(TouchCollection touches, GameTime gameTime, Viewport vp)
        {
            if (touches.Count > 0)
            {
                if (touches[0].State == TouchLocationState.Pressed)
                {
                    while(position.Y< vp.Height - 50)
                    {
                        position.Y += speed;
                    }
                    while(position.Y > vp.Height - 50)
                    {
                        position.Y -= fall;
                    } 
                }
            }
            base.Update(gameTime);            
        }
    }
}