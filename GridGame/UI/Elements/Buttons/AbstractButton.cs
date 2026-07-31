using GridGame.UI.Button;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Elements.Buttons {
    public abstract class AbstractButton : IButton {

        public void SetRect(Rectangle rect) {
            //
        }

        public abstract void OnClick();

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
