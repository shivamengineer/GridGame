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
    public abstract class AbstractButton : IButton {

        public Vector2 Position;
        public Rectangle backgroundRect;
        public Color backgroundRectColor = Color.LightGray;

        public void SetPosition(int x, int y) {
            Position = new Vector2(x, y);
        }

        public void SetRect(Rectangle rect) {
            backgroundRect = rect;
        }

        public void SetRectSelected(bool selected) {
            if(selected) backgroundRectColor = Color.Yellow;
            else backgroundRectColor = Color.LightGray;
        }

        public Rectangle GetRect() {
            return backgroundRect;
        }

        public abstract BuildingType GetBuildingType();

        public abstract void OnClick();

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
