using GridGame.Controllers;
using GridGame.Controllers.KeyboardClasses;
using GridGame.GameManagers.ManagerEnums;
using GridGame.Hexagons;
using GridGame.TechTree;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using GridGame.UI.Overlay.ResourcesDisplay;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.GameManagers {
    public class GameManager {

        public HexagonMap hexagonMap { get; private set; }

        private ContentLoader contentLoader;

        private Dictionary<ControllerTypes, IController> MainControllers;
        private Dictionary<ControllerTypes, IController> PausedControllers;
        private KeyboardHandler keyboardHandler;

        public DisplayManager displayManager { get; private set; }

        private bool paused = false;
        
        public GameManager() {
            MainControllers = new Dictionary<ControllerTypes, IController>();
            PausedControllers = new Dictionary<ControllerTypes, IController>();
        }

        public void LoadContent(ContentManager Content) {
            contentLoader = new ContentLoader(Content);
            displayManager = new DisplayManager(contentLoader);
            hexagonMap = new HexagonMap(contentLoader, displayManager);

            keyboardHandler = new KeyboardHandler(this);

            ControllerLoader.LoadMouseController(MainControllers, hexagonMap, displayManager);
            ControllerLoader.LoadPauseMouseController(PausedControllers, hexagonMap, displayManager);
        }

        public void TogglePaused() { paused = !paused; }

        public void Update(GameTime gameTime) {
            UpdateControllers(gameTime);
            keyboardHandler.Update(gameTime, paused, false);
            if(!paused) {
                hexagonMap.Update(gameTime, displayManager);
            }
        }

        private void UpdateControllers(GameTime gameTime) {
            if(!paused) {
                foreach(var Controller in MainControllers) {
                    Controller.Value.Update(gameTime);
                }
            } else {
                foreach(var Controller in PausedControllers) {
                    Controller.Value.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            if(!paused) {
                hexagonMap.Draw(spriteBatch);
                displayManager.Draw(spriteBatch);
            } else {
                displayManager.DrawTechTree(spriteBatch);
            }
        }

    }
}
