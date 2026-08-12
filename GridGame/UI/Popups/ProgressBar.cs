using GridGame.TextureLoading.TextureEnums;
using GridGame.TextureLoading;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using GridGame.Hexagons;
using GridGame.Constants;
using System.Diagnostics;

namespace GridGame.UI.Popups {
    public class ProgressBar : AbstractPopup {

        private int currentProduction;
        private int totalProduction;
        private bool productionSet = false;

        public bool Constructed;

        public ProgressBar(ContentLoader content) {
            background = content.GetTexture(TextureNames.BLANK_RECTANGLE);
            font = content.GetFont(FontNames.ARIAL_SMALL);

            Active = true;
            Constructed = false;
        }

        public void SetInfo(string text, int neededProduction) {
            this.text = text;

            currentProduction = 0;
            totalProduction = neededProduction;
            productionSet = true;
        }

        public int Build(int production) {
            currentProduction += production;

            if(currentProduction >= totalProduction) {
                Constructed = true;
                return currentProduction - totalProduction;
            }
            return 0;
        }

        public bool IsBuilding() {
            if(Constructed) {
                return false;
            } else if(productionSet && currentProduction >= totalProduction){
                Constructed = true;
                return false;
            } else {
                return true;
            }
        }

        public override void Update(GameTime gameTime) {
            if(Constructed) return;

            //
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            if(Constructed) return;

            position.X -= 20;
            position.Y -= 10;

            text = currentProduction + "/" + totalProduction;
            spriteBatch.DrawString(font, text, position, Color.Black);
        }

    }
}
