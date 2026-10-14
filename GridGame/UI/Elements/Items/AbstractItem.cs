using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Elements.Items {
    public abstract class AbstractItem : IItem {

        public Vector2 Position;
        public int Count;
        public Rectangle backgroundRect;

        public Color backgroundRectColor;
        public Color textColor;

        public void SetColor(ConstantsController Constants) {
            Dictionary<ConstColors, Color> Colors = Constants.ConstantsFiles[ConstantTypes.COLOR].GetColors();

            backgroundRectColor = Colors[ConstColors.ButtonNotSelected];
            textColor = Colors[ConstColors.ButtonTextColor];
        }

        public void OnMouseHover() {
            //if condition
            //  ShowItemData();
        }

        public void SetPosition(int x, int y) {
            Position = new Vector2(x, y);
        }

        public void SetCount(int amount) {
            Count = amount;
        }

        public void SetRect(Rectangle rect) {
            backgroundRect = rect;
        }

        public Rectangle GetRect() {
            return backgroundRect;
        }

        public abstract void ShowItemData();

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
