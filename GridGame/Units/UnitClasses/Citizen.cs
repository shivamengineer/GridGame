using GridGame.Constants;
using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units.UnitClasses {
    public class Citizen : AbstractUnit {

        private Color unitColor;

        public Citizen(int Q, int R, HexagonMap hexagonMap) {
            Coords = (Q, R);
            unitColor = Color.Gray;
            destRect = new Rectangle(0, 0, UnitInfo.UNIT_WIDTH, UnitInfo.UNIT_HEIGHT);
            this.hexagonMap = hexagonMap;
        }

        public override void Update(GameTime gameTime) {
            if(moving) {
                UpdatePos(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, HexagonMath hexMath) {
            if(moving) {
                DrawMoving(spriteBatch, hexMath);
            } else {
                DrawStationary(spriteBatch, hexMath);
            }
        }

        private void DrawMoving(SpriteBatch spriteBatch, HexagonMath hexMath) {
            Vector2 posBefore = hexMath.HexToPixel(Coords.Item1, Coords.Item2);
            Vector2 targetPos = hexMath.HexToPixel(TargetCoords.Item1, TargetCoords.Item2);

            Vector2 position = Vector2.Lerp(posBefore, targetPos, progress);
            SetDestRectDimensions(position, hexMath);

            spriteBatch.Draw(texture, destRect, unitColor);
        }

        private void DrawStationary(SpriteBatch spriteBatch, HexagonMath hexMath) {
            Vector2 position = hexMath.HexToPixel(Coords.Item1, Coords.Item2);
            SetDestRectDimensions(position, hexMath);

            spriteBatch.Draw(texture, destRect, unitColor);
        }

        private void SetDestRectDimensions(Vector2 pos, HexagonMath hexMath) {
            destRect.X = (int)(pos.X + origin.X);
            destRect.Y = (int)(pos.Y + origin.Y);
            destRect.Width = (int)(UnitInfo.UNIT_WIDTH * hexMath.GetScale());
            destRect.Height = (int)(UnitInfo.UNIT_HEIGHT * hexMath.GetScale());
        }

    }
}
