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
        public int health, ammo;
        public Vector2 position;
        public string name;
        public Texture2D sprite;
        public bool alive = false;
        public bool draw = false;

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
        }

        public virtual void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Sprites/" + name);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!draw) return;
        }
    }
}
