using GridGame.Controllers;
using GridGame.GameManagers.ManagerEnums;
using GridGame.Hexagons;
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

        private Dictionary<ControllerTypes, IController> Controllers;

        private DisplayManager displayManager;

        private bool paused = false;
        
        public GameManager() {
            Controllers = new Dictionary<ControllerTypes, IController>();
        }

        public void LoadContent(ContentManager Content) {
            contentLoader = new ContentLoader(Content);
            displayManager = new DisplayManager(contentLoader);
            hexagonMap = new HexagonMap(contentLoader, displayManager);
            Controllers.Add(ControllerTypes.KEYBOARD, new KeyboardController(this));

            ControllerLoader.LoadMouseController(Controllers, hexagonMap, displayManager);
        }

        public void TogglePaused() { paused = !paused; }

        public void Update(GameTime gameTime) {
            foreach(var Controller in Controllers) {
                Controller.Value.Update(gameTime);
            }
            if(!paused) {
                hexagonMap.Update(gameTime, displayManager);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            hexagonMap.Draw(spriteBatch);
            displayManager.Draw(spriteBatch);
        }

    }
}
