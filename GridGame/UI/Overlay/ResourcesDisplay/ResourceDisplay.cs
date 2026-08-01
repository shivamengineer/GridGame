using GridGame.Constants;
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

        public ResourceDisplay(Texture2D blankTexture, SpriteFont font) {
            this.blankTexture = blankTexture;
            this.font = font;

            InitializeResources();
            InitializeItemPositions();
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

        private void InitializeItemPositions() {
            int index = 0;
            int spacing = GameConstants.WINDOW_WIDTH / resourceItems.Count;
            foreach(var item in resourceItems) {
                Rectangle background = new Rectangle((spacing * index) + UIOverlayDetails.RESOURCE_BAR_ITEM_MARGIN_X, UIOverlayDetails.RESOURCE_BAR_ITEM_Y, 
                    spacing - (2 * UIOverlayDetails.RESOURCE_BAR_ITEM_MARGIN_X), UIOverlayDetails.RESOURCE_BAR_HEIGHT - (2 * UIOverlayDetails.RESOURCE_BAR_ITEM_Y));

                item.Value.SetPosition(background.X + UIOverlayDetails.RESOURCE_BAR_ITEM_MARGIN_X, UIOverlayDetails.RESOURCE_BAR_ITEM_Y * 2);
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

        public void UpdateResource(ResourceType resourceType, int newAmount) {
            resourceItems[resourceType].SetCount(newAmount);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(blankTexture, resourcesBar, Color.Gray);

            foreach(var item in resourceItems) {
                item.Value.Draw(spriteBatch);
            }
        }

    }
}
