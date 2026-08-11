using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Popups {
    public abstract class AbstractPopup : IPopup {

        public Texture2D background;
        public SpriteFont font;

        public Vector2 position;
        public Rectangle destRect;

        public string text;

        public bool Active;

        public bool IsActive() {
            return Active;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
