using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Button {
    public interface IButton {

        public void SetRect(Rectangle rect);

        public void OnClick();

        public void Draw(SpriteBatch spriteBatch);

    }
}
