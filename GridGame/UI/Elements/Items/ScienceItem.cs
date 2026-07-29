using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Elements.Items {
    public class ScienceItem : AbstractItem {

        private SpriteFont font;
        private string text;

        public ScienceItem(SpriteFont font) {
            this.font = font;

            text = "Science: ";
        }

        public override void ShowItemData() {
            //
        }

        public override void Draw(SpriteBatch spriteBatch) {
            //
        }

    }
}
