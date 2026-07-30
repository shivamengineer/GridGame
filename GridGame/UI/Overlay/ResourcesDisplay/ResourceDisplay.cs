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
        private List<Rectangle> resourceItemBackgrounds;

        private Rectangle resourcesBar;
        private Texture2D blankTexture;

        private SpriteFont font;

        public ResourceDisplay(Texture2D blankTexture, SpriteFont font) {
            this.blankTexture = blankTexture;
            this.font = font;
            resourceItemBackgrounds = new List<Rectangle>();

            InitializeResources();
            InitializeItemPositions();
            resourcesBar = new Rectangle(0, 0, GameConstants.WINDOW_WIDTH, UIOverlayDetails.RESOURCE_BAR_HEIGHT);
        }

        private void InitializeResources() {
            resourceItems = new Dictionary<ResourceType, IItem> {
                [ResourceType.Food] = new FoodItem(font),
                [ResourceType.Gold] = new GoldItem(font),
                [ResourceType.Morale] = new MoraleItem(font),
                [ResourceType.Production] = new ProductionItem(font),
                [ResourceType.Science] = new ScienceItem(font),
            };
        }

        private void InitializeItemPositions() {
            int index = 0;
            int spacing = GameConstants.WINDOW_WIDTH / resourceItems.Count;
            foreach(var item in resourceItems) {
                Rectangle background = new Rectangle((spacing * index) + UIOverlayDetails.RESOURCE_BAR_ITEM_MARGIN_X, UIOverlayDetails.RESOURCE_BAR_ITEM_Y, 
                    spacing - (2 * UIOverlayDetails.RESOURCE_BAR_ITEM_MARGIN_X), UIOverlayDetails.RESOURCE_BAR_HEIGHT - (2 * UIOverlayDetails.RESOURCE_BAR_ITEM_Y));
                resourceItemBackgrounds.Add(background);
                item.Value.SetPosition(background.X + UIOverlayDetails.RESOURCE_BAR_ITEM_MARGIN_X, UIOverlayDetails.RESOURCE_BAR_ITEM_Y * 2);
                index++;
            }
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

            foreach(var rect in resourceItemBackgrounds) {
                spriteBatch.Draw(blankTexture, rect, Color.LightGray);
            }

            foreach(var item in resourceItems) {
                item.Value.Draw(spriteBatch);
            }
        }

    }
}
