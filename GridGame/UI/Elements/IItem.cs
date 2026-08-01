using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Elements {
    public interface IItem {

        public void OnMouseHover();

        public void SetPosition(int x, int y);

        public void SetCount(int amount);

        public void SetRect(Rectangle rect);

        public Rectangle GetRect();

        public void Draw(SpriteBatch spriteBatch);

    }
}
