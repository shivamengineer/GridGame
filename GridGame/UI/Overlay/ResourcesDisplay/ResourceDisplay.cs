using GridGame.Constants;
using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Resources;
using GridGame.UI.Elements;
using GridGame.UI.Elements.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Overlay.ResourcesDisplay {
    public class ResourceDisplay {

        private Dictionary<ResourceType, IItem> resourceItems;

        private Rectangle resourcesBar;
        private Texture2D blankTexture;

        private SpriteFont font;

        public ResourceDisplay(Texture2D blankTexture, SpriteFont font, ConstantsController Constants) {
            this.blankTexture = blankTexture;
            this.font = font;

            Dictionary<ConstUserInterface, int> UIInts = Constants.ConstantsFiles[ConstantTypes.USER_INTERFACE].GetUIInts();

            InitializeResources();
            InitializeItemPositions(Constants, UIInts);
            resourcesBar = new Rectangle(0, 0, GameConstants.WINDOW_WIDTH, UIOverlayDetails.RESOURCE_BAR_HEIGHT);
        }

        private void InitializeResources() {
            resourceItems = new Dictionary<ResourceType, IItem> {
                [ResourceType.Food] = new FoodItem(blankTexture, font),
                [ResourceType.Gold] = new GoldItem(blankTexture, font),
                [ResourceType.Morale] = new MoraleItem(blankTexture, font),
                [ResourceType.Production] = new ProductionItem(blankTexture, font),
                [ResourceType.Science] = new ScienceItem(blankTexture, font),
            };
        }

        private void InitializeItemPositions(ConstantsController Constants, Dictionary<ConstUserInterface, int> UIInts) {
            int index = 0;
            int spacing = UIInts[ConstUserInterface.WindowWidth] / resourceItems.Count;
            foreach(var item in resourceItems) {
                Rectangle background = new Rectangle((spacing * index) + UIInts[ConstUserInterface.ResourcesOverlayElementMarginX], UIInts[ConstUserInterface.ResourcesOverlayElementY], 
                    spacing - (2 * UIInts[ConstUserInterface.ResourcesOverlayElementMarginX]), UIInts[ConstUserInterface.ResourcesOverlayHeight]
                    - (2 * UIInts[ConstUserInterface.ResourcesOverlayElementY]));

                item.Value.SetColor(Constants);
                item.Value.SetPosition(background.X + UIInts[ConstUserInterface.ResourcesOverlayElementMarginX], UIInts[ConstUserInterface.ResourcesOverlayElementY] * 2);
                item.Value.SetRect(background);
                index++;
            }
        }

        public bool MouseOnDisplay(Point point) {
            return resourcesBar.Contains(point);
        }

        public IItem GetSelectedResource(Point point) {
            foreach(var item in resourceItems) {
                if(item.Value.GetRect().Contains(point)) {
                    return item.Value;
                }
            }
            return null;
        }

        public void UpdateAllResources(Dictionary<ResourceType, IResource> resourceMap) {
            foreach(var resource in resourceMap) {
                resourceItems[resource.Key].SetCount(resource.Value.GetCount());
            }
        }

        public void UpdateResource(ResourceType resourceType, PlayerResources playerResources) {
            int count = playerResources.GetResourceAmount(resourceType);
            resourceItems[resourceType].SetCount(count);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(blankTexture, resourcesBar, Color.Gray);

            foreach(var item in resourceItems) {
                item.Value.Draw(spriteBatch);
            }
        }

    }
}
