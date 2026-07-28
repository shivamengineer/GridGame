using GridGame.UI.Elements;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Overlay.ResourcesDisplay {
    public class ResourceDisplay {

        private List<IItem> resourceItems;

        public ResourceDisplay() {
            resourceItems = new List<IItem>();
        }

        public void Draw(SpriteBatch spriteBatch) {
            //foreach IItem item in resourceItems
            //item.Draw
        }

    }
}
