using GridGame.Resources;
using GridGame.UI.Elements;
using GridGame.UI.Elements.Items;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Overlay.ResourcesDisplay {
    public class ResourceDisplay {

        private Dictionary<ResourceType, IItem> resourceItems;

        public ResourceDisplay() {
            InitializeResources();
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

        public void Draw(SpriteBatch spriteBatch) {
            //foreach IItem item in resourceItems
            //item.Draw
        }

    }
}
