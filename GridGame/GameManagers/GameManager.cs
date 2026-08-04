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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.GameManagers {
    public class GameManager {

        private HexagonMap hexagonMap;
        private ContentLoader contentLoader;

        private Dictionary<ControllerTypes, IController> Controllers;

        private DisplayManager displayManager;
        
        public GameManager() {
            Controllers = new Dictionary<ControllerTypes, IController>();
        }

        public void LoadContent(ContentManager Content) {
            contentLoader = new ContentLoader(Content);
            hexagonMap = new HexagonMap(contentLoader.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND), contentLoader.GetTexture(TextureNames.BLANK_HEXAGON_BORDER));
            Controllers.Add(ControllerTypes.KEYBOARD, new KeyboardController(hexagonMap));

            displayManager = new DisplayManager(contentLoader);
            MouseDownHandler mouseDownHandler = new MouseDownHandler(displayManager.resourceManager.GetResourceDisplay(), displayManager.buttonDisplay);
            Controllers.Add(ControllerTypes.MOUSE, new MouseController(hexagonMap, mouseDownHandler));
        }

        public void Update(GameTime gameTime) {
            foreach(var Controller in Controllers) {
                Controller.Value.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            hexagonMap.Draw(spriteBatch);
            displayManager.Draw(spriteBatch);
        }

    }
}
