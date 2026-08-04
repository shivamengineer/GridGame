using GridGame.Constants;
using GridGame.Controllers;
using GridGame.Hexagons;
using GridGame.Resources;
using GridGame.TextureLoading;
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

        private HexagonMap hexagonMap;

        private ContentLoader contentLoader;

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

        protected override void LoadContent(){

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            contentLoader = new ContentLoader(Content);

            hexagonMap = new HexagonMap(contentLoader.GetTexture("BlankHexagon"), contentLoader.GetTexture("BlankHexagonBorder"));
            keyBindings = new KeyboardBindings(hexagonMap);

            resourcesManager = new ResourcesManager(contentLoader.GetTexture("BlankRectangle"), contentLoader.GetFont("Arial"));
            buttonDisplay = new ButtonDisplay(contentLoader.GetTexture("BlankRectangle"), contentLoader.GetFont("Arial"));

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
