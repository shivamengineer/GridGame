using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar;

namespace GridGame.UI.Popups {
    public class TemporaryPopup : AbstractPopup {

        private float timeElapsed;
        private float maxTime;

        public TemporaryPopup(ContentLoader content, Vector2 position, string text, int time) {
            background = content.GetTexture(TextureNames.BLANK_RECTANGLE);
            font = content.GetFont(FontNames.ARIAL);

            this.position = position;
            this.text = text;

            timeElapsed = 0f;
            maxTime = time;
            Active = true;
        }

        public override void Update(GameTime gameTime) {
            if(!Active) return;

            timeElapsed += (float)gameTime.TotalGameTime.TotalSeconds;
            if(timeElapsed > maxTime) {
                Active = false;
            }
        }
        public override void Draw(SpriteBatch spriteBatch) {
            if(!Active) return;

            spriteBatch.Draw(background, destRect, Color.LightGray);
            string drawText = text;
            spriteBatch.DrawString(font, text, position, Color.Red);
        }

    }
}
