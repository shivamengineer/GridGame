using GridGame.UI.Overlay.ResourcesDisplay;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Resources {
    public class ResourcesManager {

        private PlayerResources playerResources;
        private ResourceDisplay resourceDisplay;

        public ResourcesManager(Texture2D blankTexture, SpriteFont font) {
            playerResources = new PlayerResources();
            resourceDisplay = new ResourceDisplay(blankTexture, font);
            resourceDisplay.UpdateAllResources(playerResources.GetResourceCounts());
        }

        public ResourceDisplay GetResourceDisplay() {
            return resourceDisplay;
        }

        public void Draw(SpriteBatch spriteBatch) {
            resourceDisplay.Draw(spriteBatch);
        }
    }
}
