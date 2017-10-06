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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace AlecAndroidIntro
{
    class Sprite
    {
        public Texture2D image;
        public Vector2 position;
        Color color;
        public Rectangle hitbox;
        public Sprite(Texture2D Image, Vector2 Position, Color Color)
        {
            image = Image;
            position = Position;
            color = Color;
            hitbox = new Rectangle((int)position.X, (int)position.Y, image.Height, image.Width);
        }
        public void Update(GameTime gametime)
        {
            hitbox = new Rectangle(new Point((int)position.X, (int)position.Y), new Point(image.Height, image.Width));
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, color);
        }
    }

}