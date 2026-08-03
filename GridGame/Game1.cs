using GridGame.Constants;
using GridGame.Controllers;
using GridGame.Hexagons;
using GridGame.Resources;
using GridGame.UI.Overlay.ResourcesDisplay;
using GridGame.UI.Overlay.SelectActions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace GridGame {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont font;

        private Texture2D hexTexture;
        private Texture2D hexTexture2;
        private HexagonMap hexagonMap;

        private Texture2D textureRect;

        private MouseController mouseController;
        private KeyboardBindings keyBindings;

        private ResourcesManager resourcesManager;
        private ButtonDisplay buttonDisplay;

        private MouseDownHandler mouseDownHandler;

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

            textureRect = Content.Load<Texture2D>("rect_blank");

            hexTexture = Content.Load<Texture2D>("hexagon_white");
            hexTexture2 = Content.Load<Texture2D>("hexagon_white_border");

            font = Content.Load<SpriteFont>("ArialFont");

            hexagonMap = new HexagonMap(hexTexture, hexTexture2);
            keyBindings = new KeyboardBindings(hexagonMap);

            resourcesManager = new ResourcesManager(textureRect, font);
            buttonDisplay = new ButtonDisplay(textureRect, font);

            mouseDownHandler = new MouseDownHandler(resourcesManager.GetResourceDisplay(), buttonDisplay);

            mouseController = new MouseController(hexagonMap, mouseDownHandler);
        }

        protected override void Update(GameTime gameTime){
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseController.Update(gameTime);
            keyBindings.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime){
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            hexagonMap.Draw(_spriteBatch);
            resourcesManager.Draw(_spriteBatch);
            buttonDisplay.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
