using GridGame.Resources;
using GridGame.TechTree;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using GridGame.UI.Overlay.SelectActions;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.GameManagers {
    public class DisplayManager {

        public ResourcesManager resourceManager;
        public ButtonDisplay buttonDisplay;
        public TechnologyController technologyController;

        public DisplayManager(ContentLoader content) {
            resourceManager = new ResourcesManager(content.GetTexture(TextureNames.BLANK_RECTANGLE), content.GetFont(FontNames.ARIAL));
            buttonDisplay = new ButtonDisplay(content.GetTexture(TextureNames.BLANK_RECTANGLE), content.GetFont(FontNames.ARIAL));
            technologyController = new TechnologyController(content, resourceManager.playerResources);
        }

        public void Draw(SpriteBatch spriteBatch) {
            resourceManager.Draw(spriteBatch);
            buttonDisplay.Draw(spriteBatch);
        }

        public void DrawTechTree(SpriteBatch spriteBatch) {
            technologyController.Draw(spriteBatch);
            resourceManager.Draw(spriteBatch);
        }

    }
}
