using GridGame.Tiles.Buildings;
using GridGame.UI.Button;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Elements.Buttons {
    public class LaboratoryButton : AbstractButton {

        private Texture2D texture;
        private SpriteFont font;
        private string text;

        public LaboratoryButton(Texture2D texture, SpriteFont font) {
            this.texture = texture;
            this.font = font;

            text = "Laboratory";
        }

        public override BuildingType GetBuildingType() {
            return BuildingType.Laboratory;
        }

        public override void OnClick() {
            //
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, backgroundRect, backgroundRectColor);
            string drawText = text;
            spriteBatch.DrawString(font, drawText, Position, Color.Red);
        }

    }
}
