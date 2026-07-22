using GridGame.Constants;
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

        private Texture2D textureRect;

        private MouseController mouseController;
        private KeyboardController keyboardController;

        public Game1(){
            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = GameConstants.WINDOW_WIDTH;
            _graphics.PreferredBackBufferHeight = GameConstants.WINDOW_HEIGHT;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize(){

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            textureRect = Content.Load<Texture2D>("rect_blue");

            hexTexture = Content.Load<Texture2D>("hexagon2");
            hexTexture2 = Content.Load<Texture2D>("hexagon");
            hexagonMap = new HexagonMap(hexTexture, hexTexture2);
            mouseController = new MouseController(hexagonMap);
            keyboardController = new KeyboardController();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime){
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseController.Update(gameTime);

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
