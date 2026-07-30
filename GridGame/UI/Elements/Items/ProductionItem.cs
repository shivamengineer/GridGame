using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Elements.Items {
    public class ProductionItem : AbstractItem {

        private SpriteFont font;
        private string text;

        public ProductionItem(SpriteFont font) {
            this.font = font;

            text = "Production: ";
        }

        public override void ShowItemData() {
            //
        }

        public override void Draw(SpriteBatch spriteBatch) {
            string drawText = text + Count;
            spriteBatch.DrawString(font, drawText, Position, Color.Red);
        }

    }
}
