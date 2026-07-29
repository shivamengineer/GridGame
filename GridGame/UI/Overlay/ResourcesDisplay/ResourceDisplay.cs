using GridGame.Constants;
using GridGame.Resources;
using GridGame.UI.Elements;
using GridGame.UI.Elements.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Overlay.ResourcesDisplay {
    public class ResourceDisplay {

        private Dictionary<ResourceType, IItem> resourceItems;

        private Rectangle resourcesBar;
        private Texture2D blankTexture;

        public ResourceDisplay(Texture2D blankTexture) {
            InitializeResources();
            InitializeItemPositions();
            resourcesBar = new Rectangle(0, 0, GameConstants.WINDOW_WIDTH, UIOverlayDetails.RESOURCE_BAR_HEIGHT);
            this.blankTexture = blankTexture;

        }

        private void InitializeResources() {
            resourceItems = new Dictionary<ResourceType, IItem> {
                [ResourceType.Food] = new FoodItem(),
                [ResourceType.Gold] = new GoldItem(),
                [ResourceType.Morale] = new MoraleItem(),
                [ResourceType.Production] = new ProductionItem(),
                [ResourceType.Science] = new ScienceItem(),
            };
        }

        private void InitializeItemPositions() {
            
        }

        public void Draw(SpriteBatch spriteBatch) {
            //spriteBatch.Draw(blankTexture, );

            //foreach IItem item in resourceItems
            //item.Draw
        }

    }
}
