using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class Sprite
    {
        private readonly Texture2D texture;
        public Vector2 Location;
        private readonly Color color;
        public Vector2 Velocity = Vector2.Zero;
        public float RotationAngle = 0;
        public Rectangle sourceRectangle;
        public Vector2 origin;

        public Sprite(Texture2D texture, Vector2 location, Color color)
        {
            this.texture = texture;
            Location = location;
            this.color = color;
            
    }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
            spriteBatch.Draw(texture,Location,sourceRectangle, color, RotationAngle, origin, 0.5f, SpriteEffects.None,1);
        }

        public virtual void Update(GameTime gameTime)
        {
            Location += Velocity;
        }





    }
}
