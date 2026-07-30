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
                item.Value.SetPosition(index * spacing, UIOverlayDetails.RESOURCE_BAR_ITEM_Y);
                index++;
            }
            resourceItems[ResourceType.Food].SetPosition(0, UIOverlayDetails.RESOURCE_BAR_Y);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(blankTexture, resourcesBar, Color.White);

            foreach(var item in resourceItems) {
                item.Value.Draw(spriteBatch);
            }
        }

    }
}
