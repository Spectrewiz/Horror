using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Horror
{
    public class Player : Obj
    {
        public static Player player;
        public int health = 100, ammo = 32,
            maxHealth = 100, maxAmmo = 32;

        public bool inMenu;

        public Player(Vector2 position)
            : base(position)
        {
            this.position = position;
            this.name = "Player";
            player = this;
            velocity = new Vector2(5, 5);
            this.health = maxHealth;
            this.alive = true;
        }

        public override void Update()
        {
            player = this;
            if (!alive) return;

            mouse = Mouse.GetState();
            key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Up) || key.IsKeyDown(Keys.W))
                position.Y -= velocity.Y;
            if (key.IsKeyDown(Keys.Down) || key.IsKeyDown(Keys.S))
                position.Y += velocity.Y;
            if (key.IsKeyDown(Keys.Right) || key.IsKeyDown(Keys.D))
                position.X += velocity.X;
            if (key.IsKeyDown(Keys.Left) || key.IsKeyDown(Keys.A))
                position.X -= velocity.X;
            if (key.IsKeyDown(Keys.Escape))
                Menu();

            if (position.Y < 0)
                position.Y = 0;
            else if (position.Y > Game.stage.Height)
                position.Y = Game.stage.Height;

            if (position.X < 0)
                position.X = 0;
            else if (position.X > Game.stage.Width)
                position.X = Game.stage.Width;
            
            base.Update();
        }

        public void Menu()
        {
            if (!inMenu)
            {
                inMenu = true;
                Game.switchGameState(State.game_menu);
            }
            else
            {
                inMenu = false;
                Game.switchGameState(State.game);
            }
        }
    }
}
