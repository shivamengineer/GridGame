using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Elements.Items {
    public class GoldItem : AbstractItem {

        private Texture2D texture;
        private SpriteFont font;
        private string text;

        public GoldItem(Texture2D texture, SpriteFont font) {
            this.texture = texture;
            this.font = font;

            text = "Gold: ";
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
