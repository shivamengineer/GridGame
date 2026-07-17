using GridGame.Controllers;
using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace GridGame {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D hexTexture;
        private Texture2D hexTexture2;
        private HexagonMap hexagonMap;

        private MouseController mouseController;

        public Game1(){
            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 800;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize(){

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            hexTexture = Content.Load<Texture2D>("hexagon2");
            hexTexture2 = Content.Load<Texture2D>("hexagon");
            hexagonMap = new HexagonMap(hexTexture, hexTexture2);
            mouseController = new MouseController(hexagonMap);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime){
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            mouseController.Update(gameTime);
            //Vector2 mousePos = Mouse.GetState().Position.ToVector2();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime){
            GraphicsDevice.Clear(Color.Gray);

            _spriteBatch.Begin();

            hexagonMap.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
