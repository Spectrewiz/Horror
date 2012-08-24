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
    //enum for Game State
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
        //actual game state
        public static State gameState = State.menu;
        //rectangles filling the entire stage and the entire screen area
        public static Rectangle stage, screen;
        //the menu
        public static MenuComponent menuComponent, gameMenu;

        //to switch the game state via a number (used with the menu indexes)
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
            //setting up rectangles
            stage = new Rectangle(0, 0, graphics.PreferredBackBufferWidth * 4, graphics.PreferredBackBufferHeight * 4);
            screen = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //init menus
            menuComponent = new MenuComponent("Play", "Controls", "Map Editor", "Exit");
            gameMenu = new MenuComponent("Resume", "Controls", "Map Editor", "Exit");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //load the menus
            menuComponent.LoadContent(Content);
            gameMenu.LoadContent(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            //switch what to update, so everything will not update at once (increase performance)
            switch (gameState)
            {
                case State.menu:
                    //update menu
                    menuComponent.Update(gameTime);
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //switch what to draw, so everything will not draw at once (increase performance)
            switch (gameState)
            {
                case State.menu:
                    //draw menu
                    spriteBatch.Begin();
                    menuComponent.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
