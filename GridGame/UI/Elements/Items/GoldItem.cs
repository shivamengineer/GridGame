using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Elements.Items {
    public class GoldItem : AbstractItem {

        private SpriteFont font;
        private string text;

        public GoldItem(SpriteFont font) {
            this.font = font;

            text = "Gold: ";
        }

        public override void ShowItemData() {
            //
        }

        public override void Draw(SpriteBatch spriteBatch) {
            string drawText = text;
            spriteBatch.DrawString(font, drawText, Position, Color.Red);
        }

    }
}
