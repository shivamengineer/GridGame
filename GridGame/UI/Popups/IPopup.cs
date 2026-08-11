using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Popups {
    public interface IPopup {

        public bool IsActive();

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);

    }
}
