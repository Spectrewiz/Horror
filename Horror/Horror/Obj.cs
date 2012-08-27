using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Horror
{
    public class Obj
    {
        public int health, mana
            maxHealth, maxMana;

        KeyboardState key,
            prevKey;
        MouseState mouse,
            prevMouse;

        public Vector2 velocity = Vector2.Zero, 
            position;
        public float rotation = 0.0f, 
            scale = 1.0f;

        public string name;

        public Texture2D sprite;

        public bool alive = false, 
            draw = false, 
            solid;

        public Rectangle area,
            imageArea;
        public Point frame;
        protected int imageNumber = 1;
        protected float imageSpeed = 1f;
        public float imageIndex = 0f;

        public Obj()
        {

        }

        public Obj(Vector2 position)
        {
            this.position = position;
        }

        public virtual void Update()
        {
            if (!alive) return;
            UpdateArea();
            PushTo(velocity, rotation);
        }

        public virtual void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Sprites/" + name);
            area = new Rectangle(0, 0, sprite.Width / imageNumber, sprite.Height);
            frame = new Point(sprite.Width / imageNumber, sprite.Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!draw) return;
        }

        public void UpdateArea()
        {
            area.X = (int)position.X - (sprite.Width / 2);
            area.Y = (int)position.Y - (sprite.Height / 2);
        }

        public virtual void PushTo(Vector2 velocity, float direction)
        {
            if (velocity == Vector2.Zero) return;
            float newX = (float)Math.Cos(MathHelper.ToRadians(direction));
            float newY = (float)Math.Sin(MathHelper.ToRadians(direction));
            position.X += velocity.X * newX;
            position.Y += velocity.Y * newY;
        }

        public virtual void Damage(int damage)
        {
            health -= damage;
        }

        public Obj Clone()
        {
            return (Obj)this.MemberwiseClone();
        }
    }
}
