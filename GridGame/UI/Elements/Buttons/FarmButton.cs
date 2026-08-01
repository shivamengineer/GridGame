using GridGame.Tiles.Buildings;
using GridGame.UI.Button;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Elements.Buttons {
    public class FarmButton : AbstractButton {

        private Texture2D texture;
        private SpriteFont font;
        private string text;

        public FarmButton(Texture2D texture, SpriteFont font) {
            this.texture = texture;
            this.font = font;

            text = "Farm";
        }

        public override BuildingType GetType() {
            return BuildingType.Farm;
        }

        public override void OnClick() {
            //
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, backgroundRect, Color.LightGray);
            string drawText = text;
            spriteBatch.DrawString(font, drawText, Position, Color.Red);
        }

    }
}
