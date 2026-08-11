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

namespace GridGame.UI.Popups {
    public class ProgressBar : AbstractPopup {

        private int currentProduction;
        private int totalProduction;

        public bool Constructed;
        private Vector2 origin;

        public ProgressBar(ContentLoader content) {
            background = content.GetTexture(TextureNames.BLANK_RECTANGLE);
            font = content.GetFont(FontNames.ARIAL);

            Active = true;
            Constructed = false;

            origin = new Vector2(background.Width / 2f, background.Height / 2f);
        }

        public void SetInfo(string text, int neededProduction) {
            this.text = text;

            currentProduction = 0;
            totalProduction = neededProduction;
        }

        public int Build(int production) {
            currentProduction += production;

            if(currentProduction >= totalProduction) {
                Constructed = true;
                return totalProduction - currentProduction;
            }
            return 0;
        }

        public bool IsBuilding() {
            if(Constructed) {
                return false;
            } else if(currentProduction >= totalProduction){
                Constructed = true;
                return false;
            } else {
                return true;
            }
        }

        public override void Update(GameTime gameTime) {
            if(!Active) return;

            //
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            if(!Active) return;

            SetDestRectDimensions(position, hexMath);

            spriteBatch.Draw(background, destRect, Color.LightGray);
            string drawText = text;
            spriteBatch.DrawString(font, text, position, Color.Red);
        }

        private void SetDestRectDimensions(Vector2 pos, HexagonMath hexMath) {
            destRect.X = (int)(pos.X + origin.X);
            destRect.Y = (int)(pos.Y + origin.Y);
            destRect.Width = (int)(PopupInfo.PROGRESS_BAR_WIDTH * hexMath.GetScale());
            destRect.Height = (int)(PopupInfo.PROGRESS_BAR_HEIGHT * hexMath.GetScale());
        }

    }
}
