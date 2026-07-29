using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Elements.Items {
    public class MoraleItem : AbstractItem {

        private SpriteFont font;
        private string text;

        public MoraleItem(SpriteFont font) {
            this.font = font;

            text = "Morale: ";
        }

        public override void ShowItemData() {
            //
        }

        public override void Draw(SpriteBatch spriteBatch) {
            //
        }

    }
}
