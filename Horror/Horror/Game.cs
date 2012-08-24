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
    public enum State
    {
        game,
        menu,
        controls,
        map_edit,
        exit,
        inventory,
        game_menu,
        options
    }

    public class Game : Microsoft.Xna.Framework.Game
    {
        public static State gameState = State.menu;
        public static Rectangle stage, screen;
        public static MenuComponent menuComponent, gameMenu;

        public static void switchGameState(int index)
        {
            switch (index)
            {
                case 0:
                    gameState = State.game;
                    break;
                case 1:
                    gameState = State.controls;
                    break;
                case 2:
                    gameState = State.map_edit;
                    break;
                case 3:
                    gameState = State.exit;
                    break;
                case 4:
                    gameState = State.inventory;
                    break;
                case 5:
                    gameState = State.menu;
                    break;
                case 6:
                    gameState = State.game_menu;
                    break;
                case 7:
                    gameState = State.options;
                    break;
            }
        }
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            stage = new Rectangle(0, 0, graphics.PreferredBackBufferWidth * 4, graphics.PreferredBackBufferHeight * 4);
            screen = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            menuComponent = new MenuComponent("Play", "Controls", "Map Editor", "Exit");
            gameMenu = new MenuComponent("Resume", "Controls", "Map Editor", "Exit");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            menuComponent.LoadContent(Content);
            gameMenu.LoadContent(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            switch (gameState)
            {
                case State.menu:
                    menuComponent.Update(gameTime);
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (gameState)
            {
                case State.menu:
                    spriteBatch.Begin();
                    menuComponent.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
