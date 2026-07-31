using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Elements.Items {
    public class MoraleItem : AbstractItem {

        private Texture2D texture;
        private SpriteFont font;
        private string text;

        public MoraleItem(Texture2D texture, SpriteFont font) {
            this.texture = texture;
            this.font = font;

            text = "Morale: ";
        }

        public override void ShowItemData() {
            //
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, backgroundRect, Color.LightGray);
            string drawText = text + Count;
            spriteBatch.DrawString(font, drawText, Position, Color.Red);
        }

    }
}
