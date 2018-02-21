using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Asteroids
{
    public class SpaceShip : Sprite
    {
        private readonly Texture2D texture;
        private readonly Vector2 location;
        private readonly Color color;
        private float speed = 0.1f;
        private float turningSpeed = MathHelper.Pi * 2 / 100;
        private float circle = MathHelper.Pi * 2;


        public SpaceShip(Texture2D texture, Vector2 location, Color color) : base(texture, location, color)
        {
            this.texture = texture;
            this.location = location;
            this.color = color;
        }

        public void Stabilize()
        {
            Vector2 direction = Velocity;
            direction.Normalize();
            Velocity.X = Velocity.X + (Velocity.X / -Velocity.X) * direction.X * speed*2;
            Velocity.Y = Velocity.Y + (Velocity.Y / -Velocity.Y) * direction.Y * speed*2;
        }


        public override void Update(GameTime gameTime)
        {
            Vector2 direction = new Vector2((float)Math.Cos(RotationAngle), (float)Math.Sin(RotationAngle));
            direction.Normalize();

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                Velocity += direction * speed;

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                Velocity -= direction * speed;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                RotationAngle -= turningSpeed % circle;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                RotationAngle += turningSpeed % circle;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                Stabilize();

            base.Update(gameTime);
        }
    }
}
